    foreach (XmlNode objXmlNode in objXmlNodeList)
    {
        // GET LONGITUDE 
        returnValue += "\r\n" + objXmlNode.ChildNodes.Item(0).InnerText;
        // GET LATITUDE 
        returnValue += "," + objXmlNode.ChildNodes.Item(1).InnerText;
    }
