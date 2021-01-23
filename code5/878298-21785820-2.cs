    static void SerializeListToXml<T>(string file, T value)
    {
        var serializer = new XmlSerializer(typeof(T));
        using (var writer = XmlWriter.Create(file))
            serializer.Serialize(writer, value);
    }
    static object DeserializeXmlToList<T>(string file)
    {
        var serializer = new XmlSerializer(typeof(T));
        using (var reader = XmlReader.Create(file))
            return (object)serializer.Deserialize(reader);
    }
