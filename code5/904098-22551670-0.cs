        class JsonStructure
        {
            public String Type { get; set; }
            public Decimal Denomination { get; set; }
            public Decimal count { get; set; }
        }
        static void Main(string[] args)
        {
            var input = "{ \"Type\": \"Token\", \"Denomination\": 2.0, \"count\": 2 }";
            var json = SimpleJson.DeserializeObject<JsonStructure>(input);
            json.count = 3;
            var output = SimpleJson.SerializeObject(json);
            if(output.Equals("{ \"Type\": \"Token\", \"Denomination\": 2.0, \"count\": 3 }"));
            {
                Console.WriteLine("Success");
            }
            Console.ReadKey();
        }
