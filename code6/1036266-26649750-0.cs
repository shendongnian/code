        public void Serialize(Store details)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Store));
            using (TextWriter writer = new StreamWriter("Xml.xml"))
            {
                serializer.Serialize(writer, details);
            }
        }
        public static Store Deserialize()
        {
            Store result;
            XmlSerializer deserializer = new XmlSerializer(typeof(Store));
            using (TextReader reader = new StreamReader("Xml.xml"))
            {
                result = deserializer.Deserialize(reader) as Store;
            }
            return result;
        }
