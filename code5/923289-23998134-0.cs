    static void ToDataSet(XmlSchemaSet xmlSchemaSet)
    {
        var schemaDataSet = new DataSet();
        schemaDataSet.ReadXmlSchema(new StringReader(GetString(xmlSchemaSet)));
        // ...
    }
    static string GetString(XmlSchemaSet xmlSchemaSet)
    {
        var settings = new XmlWriterSettings
                        {
                            Encoding = new UTF8Encoding(false, false),
                            Indent = true,
                            OmitXmlDeclaration = false
                        };
        string output;
        using (var textWriter = new StringWriterWithEncoding(Encoding.UTF8))
        {
            using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
            {
                foreach (XmlSchema s in xmlSchemaSet.Schemas())
                {
                    s.Write(xmlWriter);
                }
            }
            output = textWriter.ToString();
        }
        return output;
    }
    public sealed class StringWriterWithEncoding : StringWriter
    {
        private readonly Encoding _encoding;
        public StringWriterWithEncoding(Encoding encoding)
        {
            _encoding = encoding;
        }
        public override Encoding Encoding
        {
            get
            {
                return _encoding;
            }
        }
    }
