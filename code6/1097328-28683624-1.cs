    public string CreateXml(MyObject myObject)
                {
                    var xmlDoc = new XmlDocument();
        
                    var xmlSerializer = new XmlSerializer(myObject.GetType());
        
                    using (var xmlStream = new MemoryStream())
                    {
                        xmlSerializer.Serialize(xmlStream, myObject);
                        xmlStream.Position = 0;
                        xmlDoc.Load(xmlStream);
                        return xmlDoc.InnerXml;
                    }
                }
