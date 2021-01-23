    var xDoc = XDocument.Load(filename);
    var newxDoc = new XElement("Root", xDoc.Root
                                       .Elements()
                                       .OrderByDescending(x => (int)x.Attribute("amount"))
                                       .ThenBy(x=>(int)x.Attribute("id"))
                                );
    string xml = newxDoc.ToString();
