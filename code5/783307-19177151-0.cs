    private static void main(String[] args)
    if (complexType != null)
                        {  
                            XmlSchemaParticle particle = complexType.Particle;
                            XmlSchemaSequence sequence = particle as XmlSchemaSequence;
                            toFile = toFile + "Complex  " + complexType.Name;
                            toFile = toFile + "\n";
                            if (complexType.ContentModel != null)
                            {
                                xmlComplexContent = (XmlSchemaComplexContent)complexType.ContentModel;
                              
                                if (complexType != null)
                                {
                                    extension = (XmlSchemaComplexContentExtension)xmlComplexContent.Content;
                                    extension.BaseTypeName = complexType.QualifiedName;  // base name 
                                    sequence =(XmlSchemaSequence) extension.Particle;
                                    if (extension.BaseTypeName.Name != null)
                                    {
                                       
                                        if (sequence != null)
                                        {
                                          
                                            Out(extension.Particle);   
                                        }
                                    }
    
                                }
                            }
                                
                          else
                                Out(complexType.Particle);
                    }
          System.IO.File.WriteAllText(@"C:\\Users\\KAMALPREETDEV\\Desktop\\attributes.txt", toFile);
              
            }
    
            private static void Out(XmlSchemaParticle particle)
            {
                XmlSchemaSequence sequence = particle as XmlSchemaSequence;
                XmlSchemaChoice choice = particle as XmlSchemaChoice;
                XmlSchemaAll all = particle as XmlSchemaAll;
    
                if (sequence != null)
                {
                   
                    toFile = toFile + "  Sequence";
                    toFile = toFile + "\n";
                    for (int i = 0; i < sequence.Items.Count; i++)
                    {
                        XmlSchemaElement childElement = sequence.Items[i] as XmlSchemaElement;
                        XmlSchemaSequence innerSequence = sequence.Items[i] as XmlSchemaSequence;
                        XmlSchemaChoice innerChoice = sequence.Items[i] as XmlSchemaChoice;
                        XmlSchemaAll innerAll = sequence.Items[i] as XmlSchemaAll;
    
                        if (childElement != null)
                        {
                            
                            toFile = toFile + "    Element/Type:  " + childElement.Name + "/" + childElement.SchemaTypeName.Name;
                            toFile = toFile + "\n";
                        }
                        else Out(sequence.Items[i] as XmlSchemaParticle);
                    }
                }
