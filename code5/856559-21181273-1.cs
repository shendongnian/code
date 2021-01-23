    string name = "RFA13";
    var xdoc = XDocument.Load(path_to_xml);
    var ns = xdoc.Root.GetDefaultNamespace(); // get namespace
    // find placemark element with name you provided
    var placemark = xdoc.Descendants(ns + "Placemark")
                        .FirstOrDefault(p => (string)p.Element(ns + "name") == name);
    if (placemark != null) // check if placemark found
    {
        // assume every placemark has coordinates
        string coordinates = placemark.Descendants(ns + "coordinates")
                                      .Select(c => (string)c)
                                      .First();
    }
