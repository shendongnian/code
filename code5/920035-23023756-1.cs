    public IEnumerable<string> GetClientIdStrings(string elementXPath, string attribute)
    {
        var doc = new XmlDocument();
        doc.Load(SomeXml.xml);
        var clientIdStrings = new List<string>();
        
        foreach(var node in doc.DocumentElement.SelectNodes(elementXPath))
        {
            clientIdStrings.Add(node.Attributes[attribute].Value);
        }
        
        return clientIdStrings;
    }     
