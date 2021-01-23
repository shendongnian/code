    var xDoc = XDocument.Load(filename); // or XDocument.Parse(xmlstring);
    var elems = xDoc.Descendants("Settings").SelectMany(x => x.Elements()).ToList();
    xDoc.Root.RemoveAll();
    xDoc.Root.Add(new XElement("Settings", elems));
    var newxml = xDoc.ToString();
