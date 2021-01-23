        public static XmlDocument SerializeObjectToXML(object obj, string sElementName)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            XmlDocument xmlDoc = new XmlDocument();
            using (MemoryStream ms = new MemoryStream())
            {
               
                serializer.Serialize(ms, obj);
                ms.Position = 0;
                xmlDoc.Load(ms);
            }
            return xmlDoc;
        }
