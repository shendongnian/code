        public static string SerializeXmlToString<T>(T instance)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.Unicode;
            StringBuilder builder = new StringBuilder();
            using (StringWriter writer = new StringWriter(builder))
            using (XmlWriter xmlWriter = XmlWriter.Create(writer, settings))
            {
                serializer.Serialize(xmlWriter, instance);
            }
            return builder.ToString();
        }
        public static byte[] SerializeXml<T>(T instance)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            using (MemoryStream memStream = new MemoryStream())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(memStream, settings))
                {
                    serializer.Serialize(xmlWriter, instance);
                }
                return memStream.ToArray();
            }
        }
        public static T DeserializeXml<T>(string data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(data))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
        
        public static T DeserializeXml<T>(byte[] bytes)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using(MemoryStream stream = new MemoryStream(bytes))
            {
                return (T)serializer.Deserialize(stream);
            }
        }
