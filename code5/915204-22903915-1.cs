    class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string json1 = @"
            {
                ""response"" :
                [
                    { ""Id"" : 1, ""Name"" : ""Foo"" },
                    { ""Id"" : 2, ""Name"" : ""Bar"" },
                ]
            }";
            DeserializeAndDump(json1);
            string json2 = @"
            {
                ""response"" :
                {
                    ""count"" : 2,
                    ""items"" :
                    [
                        { ""Id"" : 3, ""Name"" : ""Fizz"" },
                        { ""Id"" : 4, ""Name"" : ""Buzz"" },
                    ]
                }
            }";
            DeserializeAndDump(json2);
        }
        private static void DeserializeAndDump(string json)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new ItemListConverter());
            List<Item> list = JsonConvert.DeserializeObject<List<Item>>(json, settings);
            foreach (Item item in list)
            {
                Console.WriteLine("Id: " + item.Id + ", Name: " + item.Name);
            }
        }
    }
