    XmlDocument doc = new XmlDocument();
    doc.LoadXml(payload.generate());
    XmlElement newRootNode = RecursiveCopy(doc.DocumentElement, doc, "urn:org:ns");
    
    public XmlElement RecursiveCopy(XmlNode node, XmlDocument doc, string targetNamespace) 
    {  
        XmlElement nodeCopy = doc.CreateElement(node.LocalName, targetNamespace);
        foreach (XmlNode child in node.ChildNodes) 
        {
            if (child.NodeType == XmlNodeType.Element)
            {
                nodeCopy.AppendChild(RecursiveCopy(child, doc, targetNamespace);
            }
            else if (child.NodeType == XmlNodeType.Text || child.NodeType == XmlNodeType.CDATA) 
            {
                XmlNode newNode = doc.CreateNode(child.NodeType, child.LocalName, targetNamespace);
                newNode.Value = child.Value;
                nodeCopy.AppendChild(newNode);
            }
        }
        return nodeCopy;
    }
