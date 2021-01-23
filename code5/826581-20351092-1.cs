    var xdoc = XDocument.Load(path_to_xml);
    var query = from vm in xdoc.Descendants("VM")
                select new {
                   Name = (string)vm.Attribute("name"),
                   Language = (string)vm.Element("vmLanguage").Attribute("value"),
                   Snapshot = (string)vm.Element("vmSnapshot").Attribute("value"),
                   PowerOn = (bool)vm.Element("vmPowerOn").Attribute("value"),
                   Clients = from c in vm.Element("vmClients").Elements()
                             select new {
                                Name = (string)c.Attribute("name"),
                                // etc
                             }
                };
