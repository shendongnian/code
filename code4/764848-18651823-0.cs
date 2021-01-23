    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.Load(filename); // path to the .xml file
    XmlNode selectedNode = xmlDoc.SelectSingleNode("/items/superitem/item[@id='20']");
    XmlDocument newXmlDoc = new XmlDocument();
    XmlDeclaration declaration = newXmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
    newXmlDoc.AppendChild(declaration);
    XmlNode itemsNode = newXmlDoc.CreateElement("items");
    newXmlDoc.AppendChild(itemsNode);
    XmlNode superitemNode = newXmlDoc.CreateElement("superitem");
    itemsNode.AppendChild(superitemNode);
    XmlNode itemNode = newXmlDoc.ImportNode(selectedNode, true);
    superitemNode.AppendChild(itemNode);
    newXmlDoc.Save(outputFileName); // name of the new .xml file
