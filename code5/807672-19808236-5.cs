    var list = productsXml
        .SelectNodes("/portfolio/products/product")
        .Cast<XmlNode>()
        .ToList();
    for (int i=0; i < list.Count; ++i)
    {
        var node = list[i];
    
        if (node.Attributes["name"].InnertText.StartsWith("PB_"))
          list.Add(node.ParentNode.AppendChild(document.CreateElement("product"))));
    
        insertIntoTable(node);
    }
