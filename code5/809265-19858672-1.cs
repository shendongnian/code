        public static string SerializeObjectToXML(object obj, string sElementName)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            string xml;
            using (var memoryStream = new MemoryStream())
            {
                using (var xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8))
                {
                    serializer.Serialize(xmlTextWriter, obj);
                    using (var memoryStream2 = (MemoryStream)xmlTextWriter.BaseStream)
                    {
                        xml = Encoding.UTF8.GetString(memoryStream2.ToArray());
                    }
                }
            }
            return xml;
        }
