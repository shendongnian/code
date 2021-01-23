    XElement xelement = XElement.Load("data.xml");
    var employees = xelement.Elements()
                .Select(e => new 
                {
                    Name = e.Element("Employee").Value,
                    ChangeTimestamp = DateTime.Parse(e.Element("ChangeTimestamp").Value)
                })
                .GroupBy(e => e.Name)
                .Select( g => new 
                {
                    Name = g.Key,
                    ChangeTimestamp = g.Max(e => e.ChangeTimestamp)
                });
