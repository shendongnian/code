    private static string dictToJson(Dictionary<string, object> data)
    {
        string json = JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.None,
            TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
        });
        return json;
    }
