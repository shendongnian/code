    public static void Main(string[] args)
    {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            Context = new StreamingContext(StreamingContextStates.Other, "foo")
        };
        var json = @"{ ""id"": 1, ""name"": ""Lucy"", ""age"": 22 }";
        var lucy = JsonConvert.DeserializeObject<Person>(json, settings);
        Console.ReadKey();
    }
