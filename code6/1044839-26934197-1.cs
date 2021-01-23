    var encoding = Encoding.GetEncoding("ISO-8859-1");
    var xmlWriterSettings = new XmlWriterSettings
    {
        Indent = true,
        OmitXmlDeclaration = false,
        Encoding = encoding
    };
    
    var output = new StringBuilder();
    using (var stream = new MemoryStream())
    {
        using (var xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
        {
            serializer.Serialize(xmlWriter, obj, ns);
        }
        output.Append(encoding.GetString(stream.ToArray()));
    }
    return output.ToString();
