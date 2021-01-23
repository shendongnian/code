    static T Deserialize<T>(string xml)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        XmlReaderSettings settings = new XmlReaderSettings();
        using (StringReader textReader = new StringReader(xml))
        {
            using (XmlReader xmlReader = XmlReader.Create(textReader, settings))
            {
                return (T)serializer.Deserialize(xmlReader);
            }
        }
    }
