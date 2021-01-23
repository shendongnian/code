    static T GetValue<T>(SqlXml sqlXml)
    {
        T value;
        // using System.Xml;
        using (XmlReader xmlReader = sqlXml.CreateReader())
        {
            // using System.Xml.Serialization;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            value = (T) xmlSerializer.Deserialize(xmlReader);
        }
        return value;
    }
