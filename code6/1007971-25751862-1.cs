    XmlElement rootelement = doc.CreateElement(string.Empty, 
                             "DeviceDescription", string.Empty);
    doc.AppendChild(rootelement);
    
    XmlNode typesNode = doc.CreateElement("Types");
    XmlAttribute typesAttribute = doc.CreateAttribute("namespace");
    typesAttribute.Value = "localTypes";
    typesNode.Attributes.Append(typesAttribute);
    rootelement.AppendChild(typesNode);
