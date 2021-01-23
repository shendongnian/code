    var root = XElement.Parse("<root>" + colorXml + "</root>");
    var colors = root.Nodes()
        .Where(n => n.NodeType == XmlNodeType.Element)
        .Select(node =>
        {
            var element = (XElement)node;
            return new Color()
            {
                Id = Convert.ToInt32(element.Attribute("colorId").Value),
                Name = element.Attribute("colorName").Value
            };
        }).ToList();
