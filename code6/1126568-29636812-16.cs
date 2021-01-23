    public static class XmlSerializationExtensions
    {
        public static string ToXml<T>(this T obj)
        {
            return obj.ToXml(false);
        }
        public static string ToXml<T>(this T obj, bool omitStandardNamespaces)
        {
            using (var textWriter = new StringWriter())
            {
                var settings = new XmlWriterSettings() { Indent = true, IndentChars = "  " }; // For cosmetic purposes.
                using (var writer = XmlWriter.Create(textWriter, settings))
                {
                    XmlSerializerNamespaces ns = null;
                    if (omitStandardNamespaces)
                        (ns = new XmlSerializerNamespaces()).Add("", ""); // Disable the xmlns:xsi and xmlns:xsd lines.
                    new XmlSerializer(obj.GetType()).Serialize(writer, obj, ns);
                }
                return textWriter.ToString();
            }
        }
        public static T DeserializeXML<T>(this string xmlString)
        {
            using (var reader = new StringReader(xmlString))
            {
                var result = new XmlSerializer(typeof(T)).Deserialize(reader);
                if (result is T)
                    return (T)result;
            }
            return default(T);
        }
        public static XElement ToXElement<T>(this T obj)
        {
            return obj.ToXElement(true);
        }
        public static XElement ToXElement<T>(this T obj, bool omitStandardNamespaces)
        {
            var doc = new XDocument();
            using (var writer = doc.CreateWriter())
            {
                XmlSerializerNamespaces ns = null;
                if (omitStandardNamespaces)
                    (ns = new XmlSerializerNamespaces()).Add("", ""); // Disable the xmlns:xsi and xmlns:xsd lines.
                new XmlSerializer(obj.GetType()).Serialize(writer, obj, ns);
            }
            var element = doc.Root;
            if (element != null)
                element.Remove();
            return element;
        }
        public static T DeserializeXML<T>(this XContainer element)
        {
            using (var reader = element.CreateReader())
            {
                var result = new XmlSerializer(typeof(T)).Deserialize(reader);
                if (result is T)
                    return (T)result;
            }
            return default(T);
        }
    }
