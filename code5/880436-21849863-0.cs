    var content = XDocument.Load("content.xml")
                           .Root.Elements("page")
                           .ToDictionary(p => (int)p.Attribute("no"),
                                         p => (string)p);
    var xdoc = XDocument.Load("template.xml");
    foreach (var page in xdoc.Descendants("page"))
    {
        string data;
        if (!content.TryGetValue((int)page.Attribute("no"), out data))
            continue;
        page.Value = data;
    }
