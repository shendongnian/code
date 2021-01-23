    var xdoc = XDocument.Load(@"C:\Program Files\Config.xml");
    var ns = xdoc.Root.GetDefaultNamespace();
    var parameter = 
        xdoc.Root.Elements(ns + "Service")
            .Where(s => (string)s.Attribute("name") == "InfoRepositoryClient")
            .Elements(ns + "Environment")
            .Elements(ns + "Parameter")
            .Where(p => (string)p.Attribute("name") == "ORBPreferredInterfaces")
            .Select(p => (string)p.Attribute("value"))
            .FirstOrDefault();
