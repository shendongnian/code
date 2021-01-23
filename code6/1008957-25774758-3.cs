    public static class XmlSerializationHelper
    {
        public static string GetXml<T>(T obj, XmlSerializer serializer) where T : class
        {
            using (var textWriter = new StringWriter())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;        // For cosmetic purposes.
                settings.IndentChars = "    "; // The indentation used in the test string.
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    serializer.Serialize(xmlWriter, obj);
                }
                return textWriter.ToString();
            }
        }
        public static string GetXml<T>(T obj) where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            return GetXml(obj, serializer);
        }
    }
