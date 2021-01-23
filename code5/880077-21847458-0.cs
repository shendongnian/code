    var xe = new XElement("test",
        new XElement("child1"),
        new XElement("child2"));
    var sb = new StringBuilder();
    using (var writer = new StringWriter(sb))
    using (var xr = XmlWriter.Create(writer, new XmlWriterSettings()
    {
        OmitXmlDeclaration = true
    }))
    {
        xe.Save(xr);
    }
    sb.Replace(" />", "/>");
