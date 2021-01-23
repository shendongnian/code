    XmlDocument xdoc = new XmlDocument();
    xdoc.Load("file path");
    XElement xElement = XElement.Parse(xdoc.OuterXml);
    XNamespace xNamespace = xElement.GetDefaultNamespace();
    xdoc.LoadXml(xElement.ToString().Replace("xmlns=\"" + xNamespace.ToString() + "\"", ""));     
    int nodeCount = xdoc.SelectNodes("/SubscriptionOperationCollection/SubscriptionOperations").Count;
