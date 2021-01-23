    public static void SerializeToStream(MyObject obj, Stream stream)
    {
        var settings = GetJsonSerializerSettings();
        settings.Formatting = Formatting.Indented;
        var serializer = JsonSerializer.Create(settings);
        using (var sw = new StreamWriter(stream))
        using (var jsonTextWriter = new JsonTextWriter(sw))
        {
            serializer.Serialize(jsonTextWriter, obj);
        }
    }
