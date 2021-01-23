    XElement xelement = XElement.Load("data.xml");
    xelement.Elements()
        .GroupBy(e => e.Element("Employee").Value)
        .SelectMany(g =>
        {
            var maxDate = g.Max( e => DateTime.Parse(e.Element("ChangeTimestamp").Value));
            return g.Where(e => DateTime.Parse(e.Element("ChangeTimestamp").Value) != maxDate);
        })
        .ToList()
        .ForEach(e=>e.Remove());
