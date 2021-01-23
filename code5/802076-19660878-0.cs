    public class Config<T> where T : class
    {
        public static T Load()
        {
            using (var reader = new StreamReader("config.xml"))
            {
                return (T)(new XmlSerializer(typeof(T))).Deserialize(reader);
            }
        }
    }
