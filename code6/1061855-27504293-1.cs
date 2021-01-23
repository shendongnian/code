            string xml = @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>
    <Document xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""mondoc"" xls:schemaLocation=""mondoc.xsd"">
    </Document>
    ";
            XmlDocument xmlDoc;
            using (var stream = new StringReader(xml))
            {
                var settings = new XmlReaderSettings();
                settings.NameTable = new NameTable();
                var manager = new MyXmlNamespaceManager(settings.NameTable);
                XmlParserContext context = new XmlParserContext(null, manager, null, XmlSpace.Default);
                using (var xmlReader = XmlReader.Create(stream, settings, context))
                {
                    xmlDoc = new XmlDocument();
                    xmlDoc.Load(xmlReader);
                }
            }
            string newXml;
            using (var writer = new StringWriter())
            {
                xmlDoc.Save(writer);
                newXml = writer.ToString();
            }
            Debug.WriteLine(newXml);
