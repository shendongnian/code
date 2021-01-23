    class Program
    {
        static void Main(string[] args)
        {
            List<Form> forms = new List<Form>
            {
                new Form 
                { 
                    Id = 1, 
                    Field = "One", 
                    NestedObject = new Form
                    {
                        Id = 2,
                        Field = "Two"
                    }
                },
                new Form
                {
                    Id = 3,
                    Field = "Three"
                },
                new Form
                {
                    Id = 4,
                    Field = "Four"
                },
                new Form
                {
                    Id = 5,
                    Field = "Five"
                }
            };
            forms[0].NestedObject.NestedObject = forms[3];
            forms[1].NestedObject = forms[0].NestedObject;
            forms[2].NestedObject = forms[1];
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new SerializationConverter() },
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                Formatting = Formatting.Indented
            };
            string json = JsonConvert.SerializeObject(forms, settings);
            Console.WriteLine(json);
        }
    }
