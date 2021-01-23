    public static class XObjectExtensions
    {
        public static T Deserialize<T>(this XElement element)
        {
            return element.Deserialize<T>(new XmlSerializer(typeof(T)));
        }
        public static T Deserialize<T>(this XElement element, XmlSerializer serial)
        {
            using (var reader = element.CreateReader())
            {
                object result = serial.Deserialize(reader);
                if (result is T)
                    return (T)result;
            }
            return default(T);
        }
    }
