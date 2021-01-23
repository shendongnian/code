    var xdoc = XDocument.Load(path_to_xml);
    var windows = xdoc.Root.Elements().Where(e => e.Name.LocalName != "NUMBER")
                      .Select(n => new TimeWindow {
                          From = (string)n.Element("FROM"),
                          To = (string)n.Element("TO")
                       }).ToList();
