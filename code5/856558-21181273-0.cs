    string name = "RFA13";
    var xdoc = XDocument.Load(path_to_xml);
    var ns = xdoc.Root.GetDefaultNamespace();
    var placemark = xdoc.Descendants(ns + "Placemark")
                        .FirstOrDefault(p => (string)p.Element(ns + "name") == name);
    if (placemark != null)
    {
        var coordinates = placemark.Descendants(ns + "coordinates")
                                   .Select(c => (string)c)
                                   .First();
    }
