    static void Main() {
        var settings = new XmlReaderSettings();
        settings.NameTable = new NameTable();
        var nsMgr = new XmlNamespaceManager(settings.NameTable);
        nsMgr.AddNamespace("", "http://example.com/2013/ns"); // <-- set default namespace
        settings.ValidationType = ValidationType.Schema;
        settings.Schemas.Add(null, @"C:\XSDSchema.xsd"); // <-- set schema location for the default namespace
        var parserCtx = new XmlParserContext(settings.NameTable, nsMgr, XmlSpace.Default);
        using (var reader = XmlReader.Create(@"C:\file.xml", settings, parserCtx)) {
            var serializer = new XmlSerializer(typeof(Foo));
            Foo f = (Foo)serializer.Deserialize(reader);
        }
    }
