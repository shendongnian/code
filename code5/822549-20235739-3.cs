     using (var rdr = System.Xml.XmlReader.Create(@"input.xml"))
                {
                    var root=new System.Xml.Serialization.XmlRootAttribute("root");
                    var ser = new System.Xml.Serialization.XmlSerializer(typeof(List<MyXMLElements>),root);
                    var list=(List<MyXMLElements>)ser.Deserialize(rdr);
                }
