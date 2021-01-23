    public static class TestClass
    {
        public static void Test()
        {
            var curpit11 = new EPIT11V21(10101);
            var xml = XmlSerializationHelper.GetXml(curpit11, NameSpaces.XmlSerializerNamespaces);
            Debug.WriteLine(xml);
        }
    }
    public static class XmlSerializationHelper
    {
        public static string GetXml<T>(this T obj)
        {
            return GetXml(obj, false);
        }
        public static string GetXml<T>(this T obj, bool omitNamespace)
        {
            return GetXml(obj, new XmlSerializer(obj.GetType()), omitNamespace);
        }
        public static string GetXml<T>(this T obj, XmlSerializer serializer)
        {
            return GetXml(obj, serializer, false);
        }
        public static string GetXml<T>(T obj, XmlSerializer serializer, bool omitStandardNamespaces)
        {
            XmlSerializerNamespaces ns = null;
            if (omitStandardNamespaces)
            {
                ns = new XmlSerializerNamespaces();
                ns.Add("", ""); // Disable the xmlns:xsi and xmlns:xsd lines.
            }
            return GetXml(obj, serializer, ns);
        }
        public static string GetXml<T>(T obj, XmlSerializerNamespaces ns)
        {
            return GetXml(obj, new XmlSerializer(obj.GetType()), ns);
        }
        public static string GetXml<T>(T obj, XmlSerializer serializer, XmlSerializerNamespaces ns)
        {
            using (var textWriter = new StringWriter())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;        // For cosmetic purposes.
                settings.IndentChars = "    "; // For cosmetic purposes.
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    if (ns != null)
                        serializer.Serialize(xmlWriter, obj, ns);
                    else
                        serializer.Serialize(xmlWriter, obj);
                }
                return textWriter.ToString();
            }
        }
    }
