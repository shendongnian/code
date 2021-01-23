    XDocument doc = XDocument.Load(@"path");
    doc.Root.Elements("Employee")
        .GroupBy(e => e.Element("Employee").Value)
        .SelectMany(g=>
        {
            return g.OrderByDescending(e => DateTime.Parse(e.Element("ChangeTimeStamp").Value))
                .Skip(1);
        })
        .ToList()
        .ForEach(e=>e.Remove());
