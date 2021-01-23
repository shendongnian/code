    public Response ParseResponse(XPathDocument document)
    {
        var navigator = document.CreateNavigator();
        var iterator = navigator.Select("//response");
        iterator.MoveNext();
        var responseDoc = XDocument.Parse(iterator.Current.OuterXml);
        
        var element = responseDoc.Element("response");
        
        var response = new Response();
        response.Status = element.Element("status").Value;
        
        foreach(var dataElement in element.Element("Data").Elements())
        {
            response.Data.Add(new KeyValuePair<string, string>(dataElement.Name.LocalName, dataElement.Value));
        }
        
        foreach(var betaElement in element.Element("Beta").Elements())
        {
            response.Beta.Add(new KeyValuePair<string, string>(betaElement.Name.LocalName, betaElement.Value));
        }
        
        return response;
    }
    Response response;
    using(var reader = XmlReader.Create(stream))
    {
        var doc = new XPathDocument(reader);
        response = ParseResponse(doc);
    }
