    // Load XML file.
    var doc = XDocument.Load(path);
    // Find SalesOrder element.
    var salesOrder = (from c in doc.Descendants("SalesOrder")
                     select c.Value).FirstOrDefault();
    // Find warning message elements.
    var warningMessages = (from c in doc.Descendants("WarningDescription")
                          where c.Parent != null && c.Parent.Name == "WarningMessages"
                          select c.Value).ToList();
