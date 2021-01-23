    XDocument doc = XDocument.Load("XMLFile1.xml");
    var newDocs = doc.Descendants("CLAIM")
                             .Select(d => new XDocument(new XElement("BATCH", new XElement("CLAIMS", d))));
    
    var batch = doc.Element("BATCH");
    var claims = doc.Descendants("CLAIMS");
    int i = 0;
    foreach (var newDoc in newDocs)
    {
        foreach (XAttribute xat in batch.Attributes())
        {
            newDoc.Element("BATCH").SetAttributeValue(xat.Name, xat.Value);
        }
        foreach (XElement claim in claims)
        {
            foreach (XAttribute xat in claim.Attributes())
            {
                newDoc.Descendants("CLAIMS").ElementAt(0).SetAttributeValue(xat.Name, xat.Value);
            }
        }
                
        newDoc.Save(i.ToString());
        ++i;
    }
