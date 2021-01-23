    XDocument xdoc = XDocument.Parse(xml);
    var ordered = xdoc.Descendants("data")
                      .OrderByDescending(x => int.Parse(x.Attribute("times").Value))
                      .ToArray();
    xdoc.Root.RemoveAll();
    xdoc.Root.Add(ordered);
