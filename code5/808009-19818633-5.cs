    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
                ""success"": true,
                ""message"": ""Missing ajax operation. Please contact administrator."",
                ""data"": {
                    ""mode"": ""new"",
                    ""data"": {
                        ""1"": {
                            ""CustomerCode"": ""CUST00001"",
                            ""Name"": ""Dell Asia Pacific Sdn. Bhd."",
                            ""Add1"": ""Plot 76 Mukim 11, Bukit Tengah Industrial Park; Bukit Mertajam; Pulau Pinang; 14000"",
                            ""Add2"": """",
                            ""Add3"": """",
                            ""Daddr1"": ""Level 21, Suite 21.01, The Gardens South Tower, Mid Valley City, Lingkaran Syed Putra, ; Kuala Lumpur; Wilayah Persekutuan; 59200"",
                            ""Daddr2"": """",
                            ""Daddr3"": """",
                            ""Attn"": """",
                            ""Phone"": """",
                            ""PhoneA"": """",
                            ""Fax"": """",
                            ""Area"": """",
                            ""Agent"": """",
                            ""Email"": """",
                            ""CurrCode"": ""MYR"",
                            ""Business"": """",
                            ""Term"": ""30 Days""
                        },
                        ""2"": {
                            ""CustomerCode"": ""CUST00002"",
                            ""Name"": ""Intel Technology Sdn Bhd"",
                            ""Add1"": ""Bayan Lepas Free Industrial Zone,Phase 3,Halaman Kampung Jawa; Bayan Lepas; Pulau Pinang; 11900"",
                            ""Add2"": """",
                            ""Add3"": """",
                            ""Daddr1"": ""1st Flr,Standard Chartered Bank Chambers,Lebuh Pantai;Penang; Kuala Lumpur; Wilayah Persekutuan; 10300"",
                            ""Daddr2"": """",
                            ""Daddr3"": """",
                            ""Attn"": """",
                            ""Phone"": """",
                            ""PhoneA"": """",
                            ""Fax"": """",
                            ""Area"": """",
                            ""Agent"": """",
                            ""Email"": """",
                            ""CurrCode"": ""MYR"",
                            ""Business"": """",
                            ""Term"": ""30 Days""
                        },
                        ""3"": {
                            ""CustomerCode"": ""CUST00003"",
                            ""Name"": ""Petronas Carigali Sdn. Bhd."",
                            ""Add1"": ""Tower 1, Petronas Twin Towers,Kuala Lumpur City Centre,; Kuala Lumpur; Wilayah Persekutuan; 50088"",
                            ""Add2"": """",
                            ""Add3"": """",
                            ""Daddr1"": ""Tower 1,Petronas Twin Towers,K.L.City Centre; Kuala Lumpur; Wilayah Persekutuan; 50088"",
                            ""Daddr2"": """",
                            ""Daddr3"": """",
                            ""Attn"": """",
                            ""Phone"": """",
                            ""PhoneA"": """",
                            ""Fax"": """",
                            ""Area"": """",
                            ""Agent"": """",
                            ""Email"": """",
                            ""CurrCode"": ""MYR"",
                            ""Business"": """",
                            ""Term"": ""30 Days""
                        }
                    }
                }
            }";
            CustomerRootObject obj = JsonConvert.DeserializeObject<CustomerRootObject>(json);
            foreach (KeyValuePair<int, CustomerInfo> kvp in obj.data.customers)
            {
                Console.WriteLine("----- Customer " + kvp.Key + " -----");
                Console.WriteLine("CustomerCode: " + kvp.Value.CustomerCode);
                Console.WriteLine("Name: " + kvp.Value.Name);
                Console.WriteLine("Add1: " + kvp.Value.Add1.Replace(";", "\r\n"));
            }
        }
        public class CustomerInfo
        {
            public string CustomerCode { get; set; }
            public string Name { get; set; }
            public string Add1 { get; set; }
            public string Add2 { get; set; }
            public string Add3 { get; set; }
            public string Daddr1 { get; set; }
            public string Daddr2 { get; set; }
            public string Daddr3 { get; set; }
            public string Attn { get; set; }
            public string Phone { get; set; }
            public string PhoneA { get; set; }
            public string Fax { get; set; }
            public string Area { get; set; }
            public string Agent { get; set; }
            public string Email { get; set; }
            public string CurrCode { get; set; }
            public string Business { get; set; }
            public string Term { get; set; }
        }
        public class Data
        {
            public string mode { get; set; }
            [JsonProperty("data")]
            public Dictionary<int, CustomerInfo> customers { get; set; }
        }
        public class CustomerRootObject
        {
            public bool success { get; set; }
            public string message { get; set; }
            public Data data { get; set; }
        }
    }
