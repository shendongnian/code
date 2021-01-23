     string path=@"c:\\test.xml";
    using (XmlWriter writer = XmlWriter.Create(path))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("TerminalStatusRequest");
                    writer.WriteElementString("TerminalID","AT0001");
                    writer.WriteElementString("ReaderID", "SC0001");
                    writer.WriteElementString("ComponentName","Printer");
                    writer.WriteElementString("ComponentValue","Active");
                    
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
