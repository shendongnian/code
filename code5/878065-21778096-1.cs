     using (var ms = new MemoryStream())
            {
                using (var xml = new PListWriter(ms, System.Text.Encoding.UTF8))
                {
                    xml.Formatting = Formatting.Indented;
                    xml.WriteStartDocument();
                    xml.WriteDocType();
                    xml.WriteStartElement("plist");
                    xml.WriteAttributeString("version", "1.0");
                    xml.WriteStartElement("array");
                    foreach (var element in customersArray)
                    {
                        xml.WriteStartElement("dict");
                        xml.WriteElementString("key", "Name");
                        xml.WriteElementString("string", element.Name);
                        xml.WriteElementString("key", "Code");
                        xml.WriteElementString("string", element.Code);
                    }
                    xml.WriteEndElement();
                    xml.WriteFullEndElement();
                    xml.Flush();
                    ms.Seek(0, SeekOrigin.Begin);
					
					return ms;
                }
            }
