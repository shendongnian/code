    // Setup default namespace manager for searching through nodes
    XmlNamespaceManager manager = new XmlNamespaceManager(xmldoc.NameTable);
    string defaultns = xmldoc.DocumentElement.GetNamespaceOfPrefix("");
    manager.AddNamespace("ns", defaultns);
    
    // get a list of all <Placemark> nodes
    XmlNodeList listOfPlacemark = xmldoc.SelectNodes("//ns:Placemark", manager);
    
    // iterate over the <Placemark> nodes
    foreach (XmlNode singlePlaceMark in listOfPlacemark)
    
    // Get the description subnode
    XmlNode descriptionNode = singlePlaceMark.SelectSingleNode("ns:description", manager);
    
    ..
