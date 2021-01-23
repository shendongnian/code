    var xdoc = XDocument.Load(path_to_xml);
    var orders = from o in xdoc.Root.Elements("Order")
                 select new
                 {
                     SalesOrder = (string)o.Element("SalesOrder"),
                     WarningMessages =
                         from m in o.Element("WarningMessages").Elements()
                         select (string)m
                 };
