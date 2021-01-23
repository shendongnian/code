     public class XmlHelper
     {
        public static string SerializeToXmlString<T>(T objectToSerialize, Dictionary<string, string> xmlNamespaces = null,
            string defaultNamespace = null)
        {
            StringBuilder xmlStringBuilder = new StringBuilder();
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.OmitXmlDeclaration = true;
            xmlWriterSettings.Indent = true;
            using (XmlWriter xmlWriter = XmlWriter.Create(xmlStringBuilder, xmlWriterSettings))
            {
                var xmlSerializerNamespaces = new XmlSerializerNamespaces();
                if (xmlNamespaces != null)
                {
                    foreach (var xmlNamespace in xmlNamespaces)
                    {
                        xmlSerializerNamespaces.Add(xmlNamespace.Key, xmlNamespace.Value);
                    }
                }
                var xmlSerializer = new XmlSerializer(typeof(T));
                if (defaultNamespace != null)
                    xmlSerializer = new XmlSerializer(typeof(T), defaultNamespace);
                xmlSerializer.Serialize(xmlWriter, objectToSerialize, xmlSerializerNamespaces);
            }
            return xmlStringBuilder.ToString();
        }
        public static T Deserialize<T>(string xmlText, string defaultNamespace) where T : class
        {
            using (StringReader stringReader = new StringReader(xmlText))
            {
                XmlReader xmlReader = XmlReader.Create(stringReader);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), defaultNamespace);
                return xmlSerializer.Deserialize(xmlReader) as T;
            }
        }
        /// <summary>
        /// Convert one object type to another which has a consistent serialization.
        /// </summary>
        /// <typeparam name="T">Source Class</typeparam>
        /// <typeparam name="U">Target Class</typeparam>
        /// <param name="objectToReIncarnate">Source Object of Class Type T</param>
        /// <param name="xmlNamespaces">Namespace mappings to add to serialization, if required</param>
        /// <param name="defaultNamespace">Default namespace of serialized class</param>
        /// <returns>Target Object of Class Type U</returns>
        public static U Reincarnate<T,U>(T objectToReIncarnate, Dictionary<string, string> xmlNamespaces = null,
            string defaultNamespace = null) where U : class 
        {
            string serializedObject = SerializeToXmlString(objectToReIncarnate, xmlNamespaces, defaultNamespace);
            return Deserialize<U>(serializedObject, defaultNamespace);
        }
    }
  
