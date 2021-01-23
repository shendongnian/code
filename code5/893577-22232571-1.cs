    class Program
    {
        static void Main(string[] args)
        {
            JsonPayload payload = new JsonPayload
            {
                Item1 = "Value1",
                Item2 = "Value2",
                Fields = new List<JsonField>
                {
                    new JsonField { Key = "Key1", Value = "Value1", OtherParam = "other1" },
                    new JsonField { Key = "Key2", Value = 42, OtherParam = "other2" },
                }
            };
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new JsonFieldListConverter());
            settings.Formatting = Formatting.Indented;
            string json = JsonConvert.SerializeObject(payload, settings);
            Console.WriteLine(json);
        }
    }
