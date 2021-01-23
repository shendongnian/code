    string yourXml = ".....";
    System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
    xmlDoc.LoadXml(yourXml);
    string yourXmlWithoutTags = xmlDoc.InnerText;
    string someContentWithoutTags = xmlDoc.SelectSingleNode("root/house").InnerText;
