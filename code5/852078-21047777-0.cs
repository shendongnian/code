    public void deleteXmlNode(string xmlNodeName, string xmlNodeValue)
    {
         XDocument xDoc = XDocument.Load(_connection);
         var xNodeList = xDoc.Descendants(xmlNodeName).Where(n => n.Value == xmlNodeValue);
         xNodeList.Remove();
    }
