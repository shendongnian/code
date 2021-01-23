    public static string XMLSelect(string _xmldoc, string _xpath)
    {
        string returnedValue = string.Empty;
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(_xmldoc);        
        XmlElement root = doc.DocumentElement;
        return (string)doc.SelectNodes(_xpath)[0].InnerText; 
    }
