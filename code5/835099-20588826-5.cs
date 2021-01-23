    XElement invoice = xdoc.Root.Elements("Invoice").LastOrDefault();
    if (invoice == null)
    {
        // throw exception or create and add new Invoice element
    }
    XElement items = invoice.Element("Items");
    if (items == null)
    {
        // throw exception or create and add new Items element
    }
    // create and add Item elements to items, as described above
