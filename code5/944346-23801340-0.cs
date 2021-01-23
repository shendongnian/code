    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.LoadXml(OrderXml);
    XmlNode parentNode = xmlDoc.SelectSingleNode("SalesOrders");
    XmlNode SalesOrderNode = xmlDoc.SelectSingleNode("SalesOrder");
    XmlNodeList lstWarning = xmlDoc.SelectNodes("WarningMessages/WarningDescription");
    foreach (XmlNode childrenNode in lstWarning)
    { 
        string test = childrenNode.InnerText;
    }
