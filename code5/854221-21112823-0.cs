    XElement[] messages = Enumerable.Range(0,5).Select(n => new XElement(
        "n", 
        new XAttribute("page",""), 
        new XAttribute("sequence",""),
        new XAttribute("priority","")
        // Other attributes
    )).ToArray(); // Here messages is just an array of XElement, but you can fill it with other means
   
    XDocument triggerDocument = new XDocument(
                       new XDeclaration("1.0", "utf-8", null));
    XElement triggerRoot = new XElement("config",
        new XElement("maketool-config",
        new XElement("hmi",
        new XElement("Messages",messages)))
    );
    triggerDocument.Add(triggerRoot);
