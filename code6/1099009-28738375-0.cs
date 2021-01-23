    XDocument Doc = XDocument.Parse(StringXML);
    
    var RootNode= Doc.Root;
    string NodeName = RootNode.Name.ToString();
    string AttributeValue = RootNode.Attribute("id").Value;
