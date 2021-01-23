    public static class TestClass
    {
        public static string GetXmlWithNamespaces<T>(T obj, XmlSerializerNamespaces namespaces)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            using (var textWriter = new StringWriter())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;        // For cosmetic purposes.
                settings.IndentChars = "    "; // For cosmetic purposes.
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    serializer.Serialize(xmlWriter, obj, namespaces);
                }
                return textWriter.ToString();
            }
        }
        public static void Test()
        {
            var curpit11 = new EPIT11V21(10101);
            var xml = GetXmlWithNamespaces(curpit11, NameSpaces.XmlSerializerNamespaces);
            Debug.WriteLine(xml);
        }
    }
