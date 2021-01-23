    public class XmlSerializer<T>
    {
        /// <summary>
        /// Load a Xml File and Deserialize into and object         
        /// </summary>
        /// <param name="xml">Xml String</param>
        /// <returns>Object representing the xml.</returns>
        public T DeserializeXml(String xml)
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
        public String SerializeXml(T obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, obj);
                return writer.ToString();
            }
        }
        /// <summary>
        /// Converts object T to a xml string with no prolog
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public String SerializeToXmlString(T obj)
        {
            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(obj.GetType());
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, obj, emptyNamepsaces);
                return stream.ToString();
            }
        }
    }
