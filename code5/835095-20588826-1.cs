    XDocument xdoc = XDocument.Load(path_to_xml);
    // or with XPath: xdoc.XPathSelectElement("Invoices/Invoice/Items");
    XElement items = xdoc.Root.Element("Invoice").Element("Items");
    
    for(int i = 0; i < (dataGridView2.Rows.Count - 1); i++)
    {
        var item = new XElement("Item",
                      new XElement("Model", n[i, 0]),
                      new XElement("Quantity", n[i, 1]),
                      new XElement("ItemPrice", n[i, 2]));
        items.Add(item);
    }
    
    xdoc.Save(path_to_xml);
