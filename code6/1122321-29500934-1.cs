    public static class XmlSerializerExtensions
    {
        class NullEncodingStringWriter : StringWriter
        {
            public override Encoding Encoding { get { return null; } } 
        }
        public static string Serialize<T>(this T obj, XmlSerializer serializer = null, bool indent = true)
        {
            if (serializer == null)
                serializer = new XmlSerializer(obj.GetType());
            // Precisely emulate the output of http://referencesource.microsoft.com/#System.Xml/System/Xml/Serialization/XmlSerializer.cs,2c706ead96e5c4fb
            // - Indent by 2 characters
            // - Suppress output of the "encoding" tag.
            using (var textWriter = new NullEncodingStringWriter())
            {
                using (var xmlWriter = new XmlTextWriter(textWriter))
                {
                    if (indent)
                    {
                        xmlWriter.Formatting = Formatting.Indented;
                        xmlWriter.Indentation = 2;
                    }
                    serializer.Serialize(xmlWriter, obj);
                }
                return textWriter.ToString();
            }
        }
    }
