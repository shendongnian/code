        public static Object_Name_Here LoadFromXMLString(string xmlText)
        {
            var stringReader = new System.IO.StringReader(xmlText);
            var serializer = new XmlSerializer(typeof(Object_Name_Here));
            return serializer.Deserialize(stringReader) as Object_Name_Here;
        }
