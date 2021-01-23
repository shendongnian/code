    public static class XmlHelper
    {
        public static T Load<T>(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using(FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                return (T)serializer.Deserialize(stream);
            }
        }
    
        public static void Save<T>(T obj, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using(FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(stream, obj);
            }
        }
    }
