    using (FileStream stream = new FileStream("FilePath",FileMode.Create))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(YourClass));
                        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                        ns.Add("", "");                    
                        serializer.Serialize(stream," Your Object to Serialize");
                    }
