    using System.Xml;
    
    ...
    
    XmlDocument MyXmlFile = new XmlDocument();
    MyXmlFile.LoadXml(PATH_TO_MY_XML);
    
    // Using 
    XmlNode xmlValueItem = MyXmlFile.GetElementsByTagName("ValueItem")[0];
    
    string position = xmlValueItem.Attributes["Position"].InnerText;
