    XDocument xDoc = XDocument.Parse(xmlString);
    var allEmployees = (from r in xDoc.Descendants("employee")
                       select new
                       {
                           Id = r.Element("id").Value,
                           Name = r.Element("name").Value
                       }).ToList();
    foreach (var r in allEmployees)
    {
        Console.WriteLine(r.Id + " " + r.Name);
    }
