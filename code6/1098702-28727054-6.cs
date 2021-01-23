    public static class XmlSerializationHelper
    {
        public sealed class StringWriterWithEncoding : StringWriter
        {
            private readonly Encoding encoding;
            public StringWriterWithEncoding(Encoding encoding)
            {
                this.encoding = encoding;
            }
            public override Encoding Encoding
            {
                get { return encoding; }
            }
        }
        public static string GetXml<T>(T obj, XmlSerializerNamespaces ns, Encoding encoding)
        {
            return GetXml(obj, new XmlSerializer(obj.GetType()), ns, encoding);
        }
        public static string GetXml<T>(T obj, XmlSerializer serializer, XmlSerializerNamespaces ns, Encoding encoding)
        {
            using (var textWriter = new StringWriterWithEncoding(encoding))
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
