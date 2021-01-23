    static void SerializeToXml<T>(string file, List<T> value)
    {
        var serializer = new XmlSerializer(typeof(List<T>));
        using (var writer = XmlWriter.Create(file))
            serializer.Serialize(writer, value);
    }
