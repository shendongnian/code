    public class CDataWriter
    {
        public static XDocument Transform(XDocument doc, string fileXslt)
        {
            XsltArgumentList xslArg = new XsltArgumentList();
            XslCompiledTransform trans = new XslCompiledTransform();
            trans.Load(fileXslt);
            XDocument xmlOutput = new XDocument();
            using (var writer = xmlOutput.CreateWriter())
            {
                CDataWriter info = new CDataWriter(writer);
                xslArg.AddExtensionObject("urn:cdata", info);
                trans.Transform(input: doc.CreateReader(), arguments: xslArg, results: writer);
            }
            return xmlOutput;
        }
        protected CDataWriter(XmlWriter writer) { this.writer = writer; }
        XmlWriter writer;
        public string CData(object obj)
        {
            if (obj != null && obj is System.Xml.XPath.XPathNodeIterator)
            {
                var iter = obj as System.Xml.XPath.XPathNodeIterator;
                if (iter.Count > 0 && iter.MoveNext())
                {
                    var current = iter.Current;
                    writer.WriteCData(current.OuterXml);
                }
            }
            return string.Empty;
        }
    }
    
