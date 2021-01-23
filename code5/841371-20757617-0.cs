    XmlDocument xdoc = new XmlDocument();
    xdoc.LoadXml(_LabourXMLInfo);
    // define XML namespace manager based on the XmlDocument's NameTable
    XmlNamespaceManager nsMgr = new XmlNamespaceManager(xdoc.NameTable);
    nsMgr.AddNamespace("ns", "urn:smilu.com");
    
    // add a "ns:" prefix to the XPath expression here!
    string Number = xdoc.DocumentElement.SelectSingleNode("ns:Number", nsMgr).InnerText;
