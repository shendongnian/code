    public class XmlSerializer<T>
        {
            /// <summary>
            /// Load a Xml File and Deserialize into and object         
            /// </summary>
            /// <param name="xml">Xml String</param>
            /// <returns>Object representing the xml. You should catch an InvalidCastException</returns>
            public T DeserializeXmlProductContent(String xml)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
    
                T obj;
                using (StringReader reader = new StringReader(xml))
                {
                    obj = (T)serializer.Deserialize(reader);
                }
                return obj;
    
                
            }
            /// <summary>
            /// Serialize an Object to a Xml String
            /// </summary>
            /// <param name="obj">Any Object</param>
            /// <returns>Xml String</returns>
            public String SerializeProductContentToXml(T obj)
            {
    
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
    
                using (StringWriter writer = new StringWriter())
                {
                    serializer.Serialize(writer, obj);
    
                    return writer.ToString();
                }
    
            }
        }
