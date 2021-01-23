        public static List<ModelClass> Deserialize(string xml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ModelClass));
            using (TextReader reader = new StringReader(xml))
            {
                return(List<ModelClass>)xmlSerializer.Deserialize(reader);
            }
        }
