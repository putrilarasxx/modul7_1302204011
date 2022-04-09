using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul7_1302204011
{
    class Program
    {
        static void Main(string[] args)
        {
            BankTransferConfig objekConfig = new BankTransferConfig();
            Console.WriteLine("Languange: (en/id)");
            string pilihBahasa = Console.ReadLine();
            if (pilihBahasa == "en")
            {
                Console.WriteLine(objekConfig.conf.config1.en);
            }
            else if (pilihBahasa == "id")
            {
                Console.WriteLine(objekConfig.conf.config1.id);
            }

            string nominalTransferString = Console.ReadLine();
            double nominalTransfer = double.Parse(nominalTransferString);
            double hargaAkhir = nominalTransfer;

            if (nominalTransfer <= 25000000)
            {
                Console.WriteLine("Biaya transfer: " + objekConfig.conf.config3);
            } else if (nominalTransfer > 25000000)
            {
                Console.WriteLine("Biaya transfer: " + objekConfig.conf.config4);
            }

            Console.WriteLine("Metode Transfer: RTO (real-time), SKN, RTGS, BI FAST");
            string metodeTransfer = Console.ReadLine();
            Console.WriteLine(objekConfig.conf.config5);
            hargaAkhir = nominalTransfer + nominalTransfer;
            Console.WriteLine(objekConfig.conf.config6);
            Console.WriteLine(objekConfig.conf.config7);
        }
    }
    class BankTransferConfig
    {
        public BankConfig conf;
        string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public string fileConfigName = "bank_transfer_config.json";

        public BankTransferConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch
            {
                SetDefault();
                WriteConfigFile();
            }
        }

        private void SetDefault()
        {
            PesanAwalConfig config1 = new PesanAwalConfig(
                "Please insert the amount of money to transfer:",
                "Masukkan jumlah uang yang akan di transfer:");

            string config2 = "Select transfer method / Pilih metode transfer: ";

            int config3 = 6500;
            int config4 = 15000;

            List<string> config5 = new List<string>();
            config5.Add("RTO (real-time)");
            config5.Add("SKN");
            config5.Add("RTGS");
            config5.Add("BI FAST");

            List<string> config6 = new List<string>();
            config5.Add("yes");
            config5.Add("no");

            List<string> config7 = new List<string>();
            config5.Add("ya");
            config5.Add("tidak");

            conf = new BankConfig(config1, config2, config3, config4, config5, config6, config7);
        }

        public BankConfig ReadConfigFile()
        {
            string jsonStringFromFile = File.ReadAllText(path + "/" + fileConfigName);
            conf = JsonConvert.DeserializeObject<BankConfig>(jsonStringFromFile);
            return conf;
        }

        public void WriteConfigFile()
        {
            string jsonString = JsonConvert.SerializeObject(conf, Formatting.Indented);
            string fullFilePath = path + "/" + fileConfigName;
            File.WriteAllText(fullFilePath, jsonString);
        }
    }
    class BankConfig
    {
        public PesanAwalConfig config1 { get; set; }
        public string config2 { get; set; }
        public int config3 { get; set; }
        public int config4 { get; set; }
        public List<string> config5 { get; set; }
        public List<string> config6 { get; set; }
        public List<string> config7 { get; set; }

        public BankConfig(PesanAwalConfig config1, string config2, int config3, int config4, List<string> config5, List<string> config6, List<string> config7)
        {
            this.config1 = config1;
            this.config2 = config2;
            this.config3 = config3;
            this.config4 = config4;
            this.config5 = config5;
            this.config6 = config6;
            this.config7 = config7;
        }
    }
    class PesanAwalConfig
    {
        public string en { get; set; }
        public string id { get; set; }

        public PesanAwalConfig(string en, string id)
        {
            this.en = en;
            this.id = id;
        }
    }
}
