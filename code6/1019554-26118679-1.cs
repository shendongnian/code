        static void Main(string[] args)
        {
            string xmlContent = File.ReadAllText("D:/test/data.xml");
            string xsltContent = File.ReadAllText("D:/test/style.xslt");
            string result = XsltTransform(xmlContent, xsltContent.Replace("\\\"", "\""));
        }
        static readonly XslCompiledTransform XsltCompiled = new XslCompiledTransform();
        public static string XsltTransform(string xmlContent, string xsltContent)
        {
            string result = string.Empty;
            XmlTextReader xtr = new XmlTextReader(new StringReader(xsltContent));
            XsltCompiled.Load(xtr);
            using (StringReader srXml = new StringReader(xmlContent))
            {
                using (XmlReader xrXml = XmlReader.Create(srXml))
                {
                    using (StringWriter sw = new StringWriter())
                    {
                        XsltCompiled.Transform(xrXml, null, sw);
                        result = sw.ToString();
                    }
                }
            }
            return result;
        }
