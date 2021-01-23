    class Program
    {
        static void Main(string[] args)
        {
            Document doc = new Document
            {
                Title = "How to write a JSON converter",
                Date = DateTime.Today,
                DocTypeIdentifier = new TypeIdentifier
                {
                    ParameterName = "type_id",
                    Value = "26"
                },
                OtherStuff = "this should not appear in the JSON"
            };
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new DocumentConverter());
            settings.Formatting = Formatting.Indented;
            string json = JsonConvert.SerializeObject(doc, settings);
            Console.WriteLine(json);
        }
    }
