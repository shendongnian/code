        [XmlSchemaProvider("ConfigSchema")]
        [XmlRoot(Namespace="namespace", ElementName="Config")]
        public class Config : IXmlSerializable
        {
           private static XmlSchemaSet _schema;
           public static XmlQualifiedName ConfigSchema(XmlSchemaSet xs)
           {
              _schema = xs;
              // rest of method as OP
           }
           public void ReadXml(XmlReader reader)
           {
              var settings = new XmlReaderSettings
              {
                 ValidationType = ValidationType.Schema,
                 Schemas = _schemas;
              }
              settings.ValidationEventHandler += ValidationCallBack;
              reader = XmlReader.Create(reader, settings);
              reader.Read(); // your own read logic
           }
           // rest of class
        }
