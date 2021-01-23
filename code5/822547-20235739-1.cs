     using (var rdr = System.Xml.XmlReader.Create(@"input.xml"))
                {
                    var root=new System.Xml.Serialization.XmlRootAttribute("root");
                    var ser = new System.Xml.Serialization.XmlSerializer(typeof(MyXMLElements[]),root);
                    var obj=ser.Deserialize(rdr);
                }
