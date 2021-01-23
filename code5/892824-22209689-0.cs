    public static YourClass FromXmlString(string xmlString)
    {
        var reader = new StringReader(xmlString);
        var serializer = new XmlSerializer(typeof(YourClass));
        return (YourClass)serializer.Deserialize(reader);
    }
