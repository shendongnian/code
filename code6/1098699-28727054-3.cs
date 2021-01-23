    public static class XmlSerializationHelper
    {
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
