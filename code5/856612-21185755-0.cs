    var doc = XDocument.Load("thefile.xml");
    var dictionary = doc.Element("AA").Element("BB").Element("CC").Elements("myNode")
                    .ToDictionary(x => x.Attribute("rowId").Value);
    foreach (User employee in Users)
    {
        XElement myNode;
        if (dictionary.TryGetValue(employee.ID, out myNode))
        {
                XElement nodeOfInterest = element.Elements("nodeOfInterest").FirstOrDefault();
                if (nodeOfInterest != null)
                {
                    nodeOfInterest.Value = "update with this value";
                }
                else
                {
                    XElement nodeOfInterest = new XElement("nodeOfInterest", "Add nodeOfInterest with this value");
                    element.Add(newElement);
                }
        }
  
    }
    doc.Save("TheFile.xml");
