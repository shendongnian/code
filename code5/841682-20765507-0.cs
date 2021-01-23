    public static Dictionary<String, Object> parse(byte[] json)
    {
        var reader = new StreamReader(new MemoryStream(json), Encoding.Default);
        Dictionary<String, Object> values = new JsonSerializer().Deserialize<Dictionary<string, object>>(new JsonTextReader(reader));
        return values;
    }
