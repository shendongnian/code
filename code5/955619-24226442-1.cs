    class Program
    {
        static void Main(string[] args)
        {
            Foo foo = new Foo
            {
                AnIntegerProperty = 42,
                HTMLString = "<html></html>",
                Dictionary = new Dictionary<string, string>
                {
                    { "WHIZbang", "1" },
                    { "FOO", "2" },
                    { "Bar", "3" },
                }
            };
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCaseExceptDictionaryKeysResolver(),
                Formatting = Formatting.Indented
            };
            string json = JsonConvert.SerializeObject(foo, settings);
            Console.WriteLine(json);
        }
    }
    class Foo
    {
        public int AnIntegerProperty { get; set; }
        public string HTMLString { get; set; }
        public Dictionary<string, string> Dictionary { get; set; }
    }
