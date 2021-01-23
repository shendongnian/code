    public static class XmlSerializationHelper
    {
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
    }
