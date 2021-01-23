    var xdoc = XDocument.Load(path_to_xml);
    xdoc.Root.Element("Invoice").Element("Items")
        .Add(Enumerable.Range(0, dataGridView2.Rows.Count - 1)
                       .Select(i => new XElement("Item",
                                        new XElement("Model", n[i, 0]),
                                        new XElement("Quantity", n[i, 1]),
                                        new XElement("ItemPrice", n[i, 2]))));
    xdoc.Save(path_to_xml);
