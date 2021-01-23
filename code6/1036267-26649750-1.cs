        public void Serialize<T>(T details)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextWriter writer = new StreamWriter("Xml.xml"))
            {
                serializer.Serialize(writer, details);
            }
        }
        public void Deserialize<T>(out T obj)
        {            
            XmlSerializer serializer = new XmlSerializer(typeof (T));
            using (TextReader reader = new StreamReader("Xml.xml"))
            {
                obj = (T)serializer.Deserialize(reader);
            }
        }
