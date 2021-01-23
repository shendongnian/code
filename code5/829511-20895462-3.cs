    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
                ""data"": 
                {
                    ""supplier"": 
                    {
                        ""id"": 15,
                        ""name"": ""TheOne""
                    }
                }
            }";
            Console.WriteLine("--- first run ---");
            RootObject obj = JsonConvert.DeserializeObject<RootObject>(json);
            DumpSupplier(obj.Data.Supplier);
            json = @"
            {
                ""data"": 
                {
                    ""supplier"": false
                }
            }";
            Console.WriteLine("--- second run ---");
            obj = JsonConvert.DeserializeObject<RootObject>(json);
            DumpSupplier(obj.Data.Supplier);
        }
        static void DumpSupplier(SupplierData supplier)
        {
            if (supplier != null)
            {
                Console.WriteLine("Id: " + supplier.Id);
                Console.WriteLine("Name: " + supplier.Name);
            }
            else
            {
                Console.WriteLine("(null)");
            }
            Console.WriteLine();
        }
    }
