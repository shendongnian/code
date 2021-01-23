    XmlDocument doc = new XmlDocument();            
    XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UNICODE", null);
    XmlElement root = doc.DocumentElement;
    doc.InsertBefore(xmlDeclaration, root);
...
    XmlElement rootelement = doc.CreateElement(string.Empty, 
                             "DeviceDescription", string.Empty);
    doc.AppendChild(rootelement);
    
    XmlNode typesNode = doc.CreateElement("Types");
    XmlAttribute typesAttribute = doc.CreateAttribute("namespace");
    typesAttribute.Value = "localTypes";
    typesNode.Attributes.Append(typesAttribute);
    rootelement.AppendChild(typesNode);
