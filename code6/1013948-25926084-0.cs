     public class trx
        {
            public string trx_name { get; set; }
        }
    
        public class CustomSerializer
        {
            private static void Write(string filename)
            {
                List<trx> trxs = new List<trx>();
                trxs.Add(new trx {trx_name = "Name1"});
                trxs.Add(new trx {trx_name = "Name2"});
                XmlSerializer x = new XmlSerializer(typeof (List<trx>));
                TextWriter writer = new StreamWriter(filename);
                x.Serialize(writer, trxs);
            }
    
            private static List<trx> Read(string filename)
            {
                var x = new XmlSerializer(typeof (List<trx>));
                TextReader reader = new StreamReader(filename);
                return (List<trx>) x.Deserialize(reader);
            }
        }
    }
