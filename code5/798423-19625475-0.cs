    private string CreateXDoc(IEnumerable<PassedJSONConverted> passed)
    {
        XNamespace xmlns = "http://host.adp.com";
    
        var xdec = new XDeclaration("1.0", "utf-8", "yes");
    
        var jobListElement = new XElement(xmlns + "JobXML");
    
        foreach (var objectItem in passed)
        {
            var jobXml = new XElement(xmlns + "JobsXML", 
                                new XElement(xmlns + "ID", objectItem.ID.ToString()), 
                                new XElement(xmlns + "Name", objectItem.Name), 
                                new XElement(xmlns + "Age", objectItem.Age.ToString()), 
                                new XElement(xmlns + "JobTitle", objectItem.JobTitle), 
                                new XElement(xmlns + "StartDate", objectItem.StartDate));
    
            jobListElement.Add(jobXml);
        }
    
        var doc = new XDocument(
            xdec,
            new XElement(jobListElement)
        );
    
        //Format without new lines
        return doc.ToString(SaveOptions.DisableFormatting);
    }
