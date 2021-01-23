    public static class XmlSerializationHelper
    {
        public static string Serialize<T>(T value)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StringWriter writer = new StringWriter();
            xmlSerializer.Serialize(writer, value);
            return writer.ToString();
        }
        public static T Deserialize<T>(string rawValue)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StringReader reader = new StringReader(rawValue);
            T value = (T)xmlSerializer.Deserialize(reader);
            return value;
        }
    }
