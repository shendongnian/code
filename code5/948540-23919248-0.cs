    var xDoc = new XDocument("OBJECT",
            myObjects
            .SelectMany(x => new[]
            {
                new XElement("PropA", x.PropA),
                new XElement("PropB", x.PropB)
            }));
    xDoc.Save("path")
