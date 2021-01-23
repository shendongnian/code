    XmlDocument xd = new XmlDocument();
                using (write = XmlWriter.Create(path2))
                {
                    write.WriteStartDocument();
                    write.WriteStartElement("Customers");
                    write.WriteEndElement();
                    write.WriteEndDocument();
                }
    
                xd.Load(path2);
    
                for (int i = count - 1; i >= 0; i--)
                {
    
                    XmlNode node = xdoc.ChildNodes[1].ChildNodes[i];
    
    
                    //XComment com = new XComment("-------Reversed-------");
                    XmlNode xnode = xd.CreateNode(XmlNodeType.Element, "Customer", null);
    
    
                    XmlNode nodeId = xd.CreateElement("Id");
                    nodeId.InnerText = node.ChildNodes[0].InnerText;
    
                    XmlNode nodeName = xd.CreateElement("Name");
                    nodeName.InnerText = node.ChildNodes[1].InnerText;
    
                    XmlNode nodeAge = xd.CreateElement("Age");
                    nodeAge.InnerText = node.ChildNodes[2].InnerText;
    
    
    
                    xnode.AppendChild(nodeId);
                    xnode.AppendChild(nodeName);
                    xnode.AppendChild(nodeAge);
    
    
                    xd.DocumentElement.AppendChild(xnode);
    
    
                    xd.Save(path2);
