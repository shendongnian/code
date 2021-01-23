    var root = XElement.Parse(xml);
    var att = root.Nodes().Where(n => n.NodeType == XmlNodeType.Element)
        .Select(node =>
        {
            var element = (XElement)node;
            return element.Name.LocalName.Equals("att")
                ? Tuple.Create(element.Attribute("attName").Value, ((XElement)element.FirstNode).Value)
                : Tuple.Create(element.Name.LocalName, element.Value);
        })
        .ToDictionary(tuple => tuple.Item1, tuple => tuple.Item2);
