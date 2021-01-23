    XmlDocument xmldoc = new XmlDocument();
    XmlReaderSettings settings = new XmlReaderSettings { NameTable = new NameTable() };
    XmlNamespaceManager xmlns = new XmlNamespaceManager(settings.NameTable);
    xmlns.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
    XmlParserContext context = new XmlParserContext(null, xmlns, "", XmlSpace.Default);
    XmlReader reader = XmlReader.Create(strXmlFile, settings, context);
    xmldoc.Load(reader);
