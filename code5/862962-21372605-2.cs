    class Program
    {
        static void Main(string[] args)
        {
            List<Foo> foos = new List<Foo>
            {
                new Foo
                {
                    A = "Moe",
                    B = "Larry",
                    C = "Curly",
                    IsSpecial = false
                },
                new Foo
                {
                    A = "Huey",
                    B = "Dewey",
                    C = "Louie",
                    IsSpecial = true
                },
            };
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new FooConverter());
            settings.Formatting = Formatting.Indented;
            string json = JsonConvert.SerializeObject(foos, settings);
            Console.WriteLine(json);
        }
    }
