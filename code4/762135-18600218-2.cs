    class Program
    {
        static void Main(string[] args)
        {
            FooCollection coll = new FooCollection();
            coll.Add(new Foo { Id = 1, Name = "Moe" });
            coll.Add(new Foo { Id = 2, Name = "Larry" });
            coll.Add(new Foo { Id = 3, Name = "Curly" });
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new FooCollectionConverter());
            settings.Formatting = Newtonsoft.Json.Formatting.Indented;
            string json = JsonConvert.SerializeObject(coll, settings);
            Console.WriteLine(json);
        }
    }
