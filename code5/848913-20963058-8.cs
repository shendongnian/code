    class Program
    {
        static void Main(string[] args)
        {
            Problematic obj = new Problematic
            {
                Id = 1,
                Name = "Foo"
            };
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ContractResolver = new CustomResolver();
            string json = JsonConvert.SerializeObject(obj, settings);
            Console.WriteLine(json);
        }
    }
