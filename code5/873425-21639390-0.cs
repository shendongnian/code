    var xDoc = XDocument.Load(filename); //XDocument.Parse(xmlstring);
    xDoc.Descendants()
        .SelectMany(d => d.Attributes())
        .Where(a => a.Name == "Att1" || a.Name == "Att2")
        .ToList()
        .ForEach(x => x.Remove());
    var newXml = xDoc.ToString(); //xDoc.Save(filename);
