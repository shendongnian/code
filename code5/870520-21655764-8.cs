    static void Main(string[] args){
            IPAddress ip = IPAddress.Parse("192.168.1.63");
            TcpListener tcp = new TcpListener(ip, 6666);
            tcp.Start();
            Console.WriteLine("[DEBUG] End point is: " + tcp.LocalEndpoint);
            Stopwatch time = new Stopwatch();
            time.Start();
            while (time.Elapsed < TimeSpan.FromSeconds(10)){
                TcpClient client = tcp.AcceptTcpClient();
                Console.WriteLine("Receiving message ... ");
                using (NetworkStream networkStream = client.GetStream()){
                    using (StreamReader streamReader = new StreamReader(networkStream)){
                        while (!streamReader.EndOfStream){
                            var json = streamReader.ReadLine();
                            Console.WriteLine("JSON:" + json);
                            Store store = JsonConvert.DeserializeObject<Store>(json);
                            Console.WriteLine("Data:");
                            Console.WriteLine(store.ToString());
                        }
                    }
                }
                client.Close();
                Console.WriteLine("... Message received");
            }
            tcp.Stop();
            time.Stop();
            Console.WriteLine("Server no longer working");
            Console.ReadKey();
        }
        public class Company{
            public string Name { get; set; }
        }
        public class Store : Company{
            public string Country { get; set; }
            public Dictionary<String, Double> Salaries { get; set; }
            public override string ToString()
            {
                StringBuilder str = new StringBuilder();
                str.Append(String.Format("Name= {0}; Country={1};\n Salaries:\n", Name, Country));
                if (Salaries != null)
                {
                    foreach (var salary in Salaries)
                    {
                        str.Append(String.Format("  '{0}' = {1}\n", salary.Key, salary.Value));
                    }
                }
                return str.ToString();
            }
        }
