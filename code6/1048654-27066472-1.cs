    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
                ""MinValueAsString"" : """",
                ""ARealDecimal"" : 3.14159,
                ""AnInteger"" : 42
            }";
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new DecimalJsonConverter());
            settings.Formatting = Formatting.Indented;
            Foo foo = JsonConvert.DeserializeObject<Foo>(json, settings);
            Console.WriteLine("MinValueAsString: " + foo.MinValueAsString);
            Console.WriteLine("ARealDecimal: " + foo.ARealDecimal);
            Console.WriteLine("AnInteger: " + foo.AnInteger);
            Console.WriteLine();
            json = JsonConvert.SerializeObject(foo, settings);
            Console.WriteLine(json);
        }
        class Foo
        {
            public decimal MinValueAsString { get; set; }
            public decimal ARealDecimal { get; set; }
            public decimal AnInteger { get; set; }
        }
    }
