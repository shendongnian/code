<!-- -->
    var namespaceManager = new XmlNamespaceManager(new NameTable());
    namespaceManager.AddNamespace("s", "http://schemas.xmlsoap.org/soap/envelope/");
    namespaceManager.AddNamespace("X", "http://data.usajobs.gov");
    namespaceManager.AddNamespace("XX", "http://www.hr-xml.org/3");
    namespaceManager.AddNamespace("XXX", "http://www.openapplications.org/oagis/9");
    // you'll need to change this to XPathEvaluate
    // since you're not evaluating to an element
    var JobCount = x.XPathEvaluate("/s:Envelope/s:Body/X:ShowPositionOpening/XX:DataArea/XXX:Show/@recordSetCount", namespaceManager);
