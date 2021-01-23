    XDocument doc = XDocument.Load("Test.xml");
    // this will be null
    XElement objectElementWithoutNS = doc.Root.Element("Object");
    
    XNamespace ns = doc.Root.GetDefaultNamespace();
    XElement objectElementWithNS = doc.Root.Element(ns + "Object");
