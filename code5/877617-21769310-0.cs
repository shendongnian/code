        public static string XmlString<X>(X obj, bool omitXmlDeclaration = false, bool omitNameSpace = false)
        {
            var xSer = new XmlSerializer(typeof(X));
            var settings = new XmlWriterSettings() { OmitXmlDeclaration = omitXmlDeclaration, Indent = true, Encoding = new UTF8Encoding(false) };
            using (var ms = new MemoryStream())
            using (var writer = XmlWriter.Create(ms, settings))
            {
                if (!omitNameSpace)
                {
                    xSer.Serialize(writer, obj);
                }
                else
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    xSer.Serialize(writer, obj, ns);
                }
                ms.Seek(0, 0);
                return new UTF8Encoding(false).GetString(ms.GetBuffer(), 0, (int)ms.Length);
            }
        }
