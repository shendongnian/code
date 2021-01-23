    var xdoc = XDocument.Load("data.xml");
    XNamespace ns = xdoc.Root.GetDefaultNamespace();
    var overlay = xdoc.Root.Element(ns + "GroundOverlay");
    var icon = overlay.Element(ns + "Icon");
    var box = overlay.Element(ns + "LatLonBox");
    var groundOverlay = new
    {
        Name = (string)overlay.Element(ns + "name"),
        Icon = new
        {
            Href = (string)icon.Element(ns + "href"),
            ViewBoundScale = (double)icon.Element(ns + "viewBoundScale")
        },
        LatLonBox = new
        {
            North = (double)box.Element(ns + "north"),
            South = (double)box.Element(ns + "south"),
            East = (double)box.Element(ns + "east"),
            West = (double)box.Element(ns + "west")
        }
    };
