    // Load Xml
    string xml = "";
    XDocument doc = XDocument.Parse(xml);
    
    // Get and modify element
    if (doc.Root != null)
    {
        var elementToModify = doc.Root.Elements("Customer").SingleOrDefault(x => x.Attribute("Id").Value == "2");
        if (elementToModify != null) elementToModify.SetAttributeValue("Name", "aaabbbccc");
    }
    // Add new Element
    XElement customer = doc.Descendants("Customers").FirstOrDefault();
    if (customer != null) customer.Add(new XElement("Customer", new XAttribute("Id", 3), new XAttribute("Name", "test")));
    // OR (maddy's answer)
    doc.Element("Customers").Add(new XElement("Customer", new XAttribute("Id", 3), new XAttribute("Name", "test")));
    
    // OR (Richard's answer)
    doc.Root.LastNode.AddAfterSelf(new XElement("Customer", new XAttribute("Id", 3), new XAttribute("Name", "test")));
