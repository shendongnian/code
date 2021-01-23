    XDocument xdoc = new XDocument();
    XElement root = new XElement(XName.Get("MyElement"));
    root.Add(new XAttribute(XName.Get("Text"), "Testing!"));
    root.Add(new XAttribute(XName.Get("Color"), "Red"));
    xdoc.Add(root);
    Trace.WriteLine(xdoc.ToString());
