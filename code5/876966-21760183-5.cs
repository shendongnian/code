    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
                ""Result"": {
                    ""Client"": {
                        ""ProductList"": {
                            ""Product"": [
                                {
                                    ""Name"": {
                                        ""Name"": ""Car polish""
                                    }
                                }
                            ]
                        },
                        ""Name"": {
                            ""Name"": ""Mr. Clouseau""
                        },
                        ""AddressLine1"": {
                            ""AddressLine1"": ""Hightstreet 13""
                        }
                    }
                }
            }";
            RootObject obj = JsonConvert.DeserializeObject<RootObject>(json);
            Client client = obj.Result.Client;
            foreach (Product product in client.ProductList)
            {
                Console.WriteLine(product.Name);
            }
            Console.WriteLine(client.Name);
            Console.WriteLine(client.AddressLine1);
        }
    }
