                            string baseDir = (textBox2.Text + "\\" + safeFileName);
                            string vcName = Path.GetFileName(textBox1.Text);
                            string vcProj = Path.Combine(baseDir, vcName);
                           
                            using (XmlReader reader = XmlReader.Create(textBox1.Text))
                            {
                                XmlWriterSettings settings = new XmlWriterSettings();
                                //settings.OmitXmlDeclaration = true;
                                settings.ConformanceLevel = ConformanceLevel.Auto;
                                settings.Indent = true;
                                settings.CloseOutput = false;
                                string nameSpace = "http://schemas.microsoft.com/developer/msbuild/2003";
                                using (XmlWriter writer = XmlWriter.Create(vcProj, settings))
                                {
                                    
                                    while (reader.Read())
                                    {
                                        switch (reader.NodeType)
                                        {
                                            case XmlNodeType.Element:
    
                                               if (reader.Name == "ClInclude")
                                                {
                                                    string include = reader.GetAttribute("Include"); 
                                                    string dirPath = Path.GetDirectoryName(textBox1.Text);
                                                    Directory.SetCurrentDirectory(dirPath);
                                                    string fullPath = Path.GetFullPath(include);
                                                    //string dirPath = Path.GetDirectoryName(fullPath);
                                                    //MessageBox.Show("Path: " + dirPath + Environment.NewLine + "Filename: " + filename);
                                                    copyFile(fullPath, 3);
                                                    string filename = Path.GetFileName(fullPath);
                                                    writer.WriteStartElement(reader.Name, nameSpace);
                                                    writer.WriteAttributeString("Include", "include/" + filename);
                                                    writer.WriteEndElement();
                                                   
                                                }
                                                else if (reader.Name == "ClCompile" && reader.HasAttributes)
                                                {
                                                    string include = reader.GetAttribute("Include"); 
                                                    string dirPath = Path.GetDirectoryName(textBox1.Text);
                                                    Directory.SetCurrentDirectory(dirPath);
                                                    string fullPath = Path.GetFullPath(include);
                                                    //string dirPath = Path.GetDirectoryName(fullPath);
                                                    //MessageBox.Show("Path: " + dirPath + Environment.NewLine + "Filename: " + filename);
                                                    copyFile(fullPath, 2);
                                                    string filename = Path.GetFileName(fullPath);
                                                    writer.WriteStartElement(reader.Name, nameSpace);
                                                    writer.WriteAttributeString("Include", "src/" + filename);
                                                    writer.WriteEndElement();
                                                    
                                                } 
                                               else
                                                {
                                                    writer.WriteStartElement(reader.Name, nameSpace);
                                                    writer.WriteAttributes(reader, true);
                                                }
                                               
                                                break;
    
                                            case XmlNodeType.Text:
                                                writer.WriteString(reader.Value);
                                                break;
                                            case XmlNodeType.XmlDeclaration:
                                            case XmlNodeType.ProcessingInstruction:
                                                writer.WriteProcessingInstruction(reader.Name, reader.Value);
                                                break;
                                            case XmlNodeType.Comment:
                                                writer.WriteComment(reader.Value);
                                                break;
                                            case XmlNodeType.Attribute:
                                                writer.WriteAttributes(reader, true);
                                                break;
                                            case XmlNodeType.EntityReference:
                                                writer.WriteEntityRef(reader.Value);
                                                break;
                                           case XmlNodeType.EndElement:
                                                writer.WriteFullEndElement();
                                                break;
                                                
                                            }
                                    }
                                   
                                }
                                
                            }
