    public static class XmlSerializationHelper
    {
        public static string GetXml<T>(T obj, XmlSerializer serializer, bool omitStandardNamespaces)
        {
            using (var textWriter = new StringWriter())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;        // For cosmetic purposes.
                settings.IndentChars = "    "; // For cosmetic purposes.
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    if (omitStandardNamespaces)
                    {
                        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                        ns.Add("", ""); // Disable the xmlns:xsi and xmlns:xsd lines.
                        serializer.Serialize(xmlWriter, obj, ns);
                    }
                    else
                    {
                        serializer.Serialize(xmlWriter, obj);
                    }
                }
                return textWriter.ToString();
            }
        }
        public static string GetXml<T>(this T obj, bool omitNamespace)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            return GetXml(obj, serializer, omitNamespace);
        }
        public static string GetXml<T>(this T obj)
        {
            return GetXml(obj, false);
        }
        public static T LoadFromXML<T>(this string xmlString)
        {
            return xmlString.LoadFromXML<T>(new XmlSerializer(typeof(T)));
        }
        public static T LoadFromXML<T>(this string xmlString, XmlSerializer serial)
        {
            T returnValue = default(T);
            using (StringReader reader = new StringReader(xmlString))
            {
                object result = serial.Deserialize(reader);
                if (result is T)
                {
                    returnValue = (T)result;
                }
            }
            return returnValue;
        }
        public static T LoadFromFile<T>(string filename)
        {
            XmlSerializer serial = new XmlSerializer(typeof(T));
            try
            {
                using (var fs = new FileStream(filename, FileMode.Open))
                {
                    object result = serial.Deserialize(fs);
                    if (result is T)
                    {
                        return (T)result;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
            return default(T);
        }
    }
