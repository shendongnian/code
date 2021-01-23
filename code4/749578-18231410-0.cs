    var manager = new XmlNamespaceManager(new NameTable());
    manager.AddNamespace("ns2", "XXXX");
    manager.AddNamespace("ns", "XXXXX"); // default namespace
    var names = from n in xdoc.XPathSelectElements("//ns2:feed/ns:name", manager)
                select (string)n;
