    var xdoc = XDocument.Load(path_to_xml);
    XNamespace ns = xdoc.Root.GetDefaultNamespace();
    var groups = from g in xdoc.Descendants(ns + "Group")
                 select new
                 {
                     Source = (string)g.Attribute("source")
                 };
