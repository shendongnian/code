    public class Thing:IXmlSerializable
        {      
            public List<Widget> Widgets{get;set;}
    
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                throw new NotImplementedException();
            }
    
            public System.Xml.Schema.XmlSchema GetSchema()
            {
                throw new NotImplementedException();
            }
    
            public void ReadXml(System.Xml.XmlReader reader)
            {
                throw new NotImplementedException();
            }
    
            public void WriteXml(System.Xml.XmlWriter writer)
            {
                writer.WriteStartElement("xsi","Thing", @"http://www.w3.org/2001/XMLSchema-instance");
                foreach (Widget widget in Widgets)
                {
                    if (string.IsNullOrEmpty(widget.Value))
                    {
                        writer.WriteStartElement("widget");
                        writer.WriteAttributeString("Name", widget.Name);
                        writer.WriteAttributeString("xsi", "nil", @"http://www.w3.org/2001/XMLSchema-instance", "true");                                  
                        writer.WriteEndElement();
                    }
                    else
                    {
                        writer.WriteStartElement("widget");
                        writer.WriteAttributeString("Name", widget.Name);
                        writer.WriteString(widget.Value);
                        writer.WriteEndElement();
                    }
                }
                writer.WriteEndElement();
                writer.Flush();
            }
        }
    
        public class Widget
        {
            public string Name{get;set;}
            public string Value { get; set; }
        } 
    }
    
     public static void SaveXml()
            {
                XmlWriterSettings settings= new XmlWriterSettings();
                settings.Indent = true;
                settings.OmitXmlDeclaration = true;                
    
                XmlWriter xmlWriter = XmlWriter.Create(@"c:\test.xml",settings);           
                thing.WriteXml(xmlWriter);
    
            }
