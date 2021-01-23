    protected static T ConvertXMLMessage<T>(String xmlData) where T : class, new()
    {
        var xml = new XmlDocument();
        xml.LoadXml(xmlData);
        var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
        using (var xmlReader = new XmlNodeReader(xml.DocumentElement))
        {
            T work = (T)(serializer.Deserialize(xmlReader));
            return work;
        }
    }
    protected static void WriteXMLFile<T>(T item, String saveLocation) where T : class, new()
    {
        System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(T));
        System.IO.StreamWriter file = new System.IO.StreamWriter(saveLocation);
        writer.Serialize(file, item);
        file.Close();
    }
