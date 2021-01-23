    class Program
    {
        static void Main(string[] args)
        {
            PagedResult<string> result = new PagedResult<string> { "foo", "bar", "baz" };
            result.PageIndex = 0;
            result.PageSize = 10;
            result.TotalItems = 3;
            result.TotalPages = 1;
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new PagedResultConverter<string>());
            settings.Formatting = Formatting.Indented;
            string json = JsonConvert.SerializeObject(result, settings);
            Console.WriteLine(json);
        }
    }
