    public HttpResponseMessage PostXMLFile(string serialNum, string siteNum, [ModelBinder]List<string> xmlStrings)
    {
        foreach(var xmlString in xmlStrings)
        {
           var xElement = XElement.Parse(xmlString);
           // do whatever now with your xElement;
        }
    }
