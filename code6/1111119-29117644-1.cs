      public XmlSchema GetSchema()
      {
         return null;
      }
      public void ReadXml(XmlReader reader)
      {
         reader.MoveToContent();       
         var typeName = reader.GetAttribute("TypeName");
         reader.ReadStartElement();         
         var serializer = new XmlSerializer(GetTypeByName(typeName));
         WrappedObject = serializer.Deserialize(reader);
         reader.ReadEndElement();
      }
      public void WriteXml(XmlWriter writer)
      {         
         writer.WriteAttributeString("TypeName", "", GetTypeByName(WrappedObject));
         
         var serializer = new XmlSerializer(typeof(WrappedObject));
         serializer.Serialize(writer, WrappedObject);        
      }
