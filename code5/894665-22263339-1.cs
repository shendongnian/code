    const string PrefixXml = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
    
    public static object Deserialize<T>(T obj, string xmlText)
    {
        try
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            TextReader textReader = new StringReader(xmlText);
            return (T)deserializer.Deserialize(textReader);
        }
        catch (Exception ex)
        {
            //Catch here.
            return null;
        }
    }
    public static XmlDocument Serialize<T>(T obj)
    {
        string xmlString = GerarXml.Gerar<T>(obj);
        if (!xmlString.Contains("xml version="))
        {
            xmlString = PrefixXml + xmlString;
        }
        xmlString = xmlString.Replace(Environment.NewLine, string.Empty);
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xmlString);
        return doc;
    }
