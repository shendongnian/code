    var xDoc = XDocument.Load(xmlFile);
    XPathNavigator xPathNav = xDoc.CreateNavigator();
    //position on <RecordFilingRequest>
    xPathNav.MoveToFollowing(XPathNodeType.Element);  
    //position on <RecordFilingRequestMessage>, that's the node you want
    xPathNav.MoveToFollowing(XPathNodeType.Element);
    //Get all namespaces on positioned node.
    IDictionary<string, string> namespaces = 
          xPathNav.GetNamespacesInScope(XmlNamespaceScope.All);
