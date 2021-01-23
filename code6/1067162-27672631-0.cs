    var itemsToRemove = xmlDoc.Root.Descendants("cat")
                                   .Where(x => x.Attribute("id").Value == "computer")
                                   .Descendants("item")
                                   .Where(x => x.Element("SN").Value.Trim() == Dropdownlist.Text)
                                   .ToList();
    
    otherDoc.Root.Element("cat").Add(itemsToRemove);
    
    itemsToRemove.Remove();
    
    xmlDoc.Save(@"YourXML.xml");
