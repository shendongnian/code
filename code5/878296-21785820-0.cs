    static void SerializeListToXml(string file, object list, Type type)
    {
        var serializer = new XmlSerializer(type);
        using (var writer = XmlWriter.Create(file))
            serializer.Serialize(writer, list);
    }
    static object DeserializeXmlToList(string file, Type type)
    {
        var serializer = new XmlSerializer(type);
        using (XmlReader reader = XmlReader.Create(file))
            return (object)serializer.Deserialize(reader);
    }
