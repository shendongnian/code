    var content = XDocument.Load("content.xml")
                           .Root.Elements("page")
                           .ToDictionary(p => (int)p.Attribute("no"));
    var xdoc = XDocument.Load("template.xml");
    foreach (var page in xdoc.Descendants("page"))
    {
        XElement data;
        if (!content.TryGetValue((int)page.Attribute("no"), out data))
            continue;
        page.ReplaceNodes(data.Nodes());
    }
