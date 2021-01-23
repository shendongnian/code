    public class SerializeHelperImp
    {
    
        public String SerializeToXmlString<T>(T toStringFromObject)
        {
            return SerializeToXmlString<T>(toStringFromObject, new UTF8Encoding());
        }
    
        public String SerializeToXmlString<T>(T toStringFromObject, Encoding encoding)
        {
            return DoSerializeToXmlString<T>(toStringFromObject, encoding);
        }
    
        public String SerializeToXmlString<T>(T toStringFromObject, Encoding encoding,
            XmlSerializerNamespaces namespaces)
        {
            return DoSerializeToXmlString<T>(toStringFromObject, encoding);
        }
    
        private String DoSerializeToXmlString<T>(T toStringFromObject, Encoding encoding)
        {
            String xmlstream = String.Empty;
    
            using (MemoryStream ms = new MemoryStream())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof (T));
                XmlTextWriter xmlWriter = new XmlTextWriter(ms, encoding);
    
                xmlSerializer.Serialize(xmlWriter, toStringFromObject);
                xmlstream = ByteArrayToString(ms.ToArray(), encoding);
            }
    
            return xmlstream;
        }
         private String ByteArrayToString(Byte[] arrayOfBytes, Encoding encoding)
        {
            return encoding.GetString(arrayOfBytes);
        }
    }
