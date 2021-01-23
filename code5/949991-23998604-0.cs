    using (var xwModifiedXml = XmlWriter.Create(xmlFilePath1))
    {
        using (var sr = new StringReader(File.ReadAllText(xmlFilePath2)))
        {
            XmlSchemaSet sc = new XmlSchemaSet();
            sc.Add(null, @"C:\my-schema.xsd");
            using (var xrModifiedXml = XmlReader.Create(sr, new XmlReaderSettings() { ValidationType = System.Xml.ValidationType.Schema, Schemas = sc }))
            {
                bool readResult = xrModifiedXml.Read();
                while (readResult)
                {
                    WriteShallowNode(xrModifiedXml, xwModifiedXml);
                    readResult = xrModifiedXml.Read();
                }
            }
        }
    }
    static void WriteShallowNode( XmlReader reader, XmlWriter writer )
    {
          if ( reader == null )
          {
                throw new ArgumentNullException("reader");
          }
          if ( writer == null )
          {
                throw new ArgumentNullException("writer");
          }
         
          switch ( reader.NodeType )
          {
                case XmlNodeType.Element:
                      writer.WriteStartElement( reader.Prefix, reader.LocalName, reader.NamespaceURI );
                      writer.WriteAttributes( reader, true );
                      if ( reader.IsEmptyElement )
                      {
                            writer.WriteEndElement();
                      }
                      break;
                case XmlNodeType.Text:
                      writer.WriteString( reader.Value );
                      break;
                case XmlNodeType.SignificantWhitespace:
                      // only write significant whitespace
                      writer.WriteWhitespace(reader.Value);
                      break;
                case XmlNodeType.CDATA:
                      writer.WriteCData( reader.Value );
                      break;
                case XmlNodeType.EntityReference:
                      writer.WriteEntityRef(reader.Name);
                      break;
                case XmlNodeType.XmlDeclaration:
                case XmlNodeType.ProcessingInstruction:
                      writer.WriteProcessingInstruction( reader.Name, reader.Value );
                      break;
                case XmlNodeType.DocumentType:
                      writer.WriteDocType( reader.Name, reader.GetAttribute( "PUBLIC" ), reader.GetAttribute( "SYSTEM" ), reader.Value );
                      break;
                case XmlNodeType.Comment:
                      writer.WriteComment( reader.Value );
                      break;
                case XmlNodeType.EndElement:
                      writer.WriteFullEndElement();
                      break;
          }
    }
