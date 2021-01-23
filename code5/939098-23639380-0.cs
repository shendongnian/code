    static void SerializeToXml<T>(string file, T value)
    {
        var serializer = new XmlSerializer(typeof(T));
        using (var writer = XmlWriter.Create(file))
            serializer.Serialize(writer, value);
    }
    static T DeserializeFromXml<T>(string file)
    {
        var serializer = new XmlSerializer(typeof(T));
        using (var reader = XmlReader.Create(file))
            return (T)serializer.Deserialize(reader);
    }
