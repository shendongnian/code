    public static string xmlSerialize(List<Object> o)
            {
                XmlDocument xmlOut = new XmlDocument();
    
                foreach(var i in o)
                {
                    var tmpDoc = new XmlDocument();
                    using (MemoryStream xmlStream = new MemoryStream())
                    {
                        //MemoryStream myMemStr = new MemoryStream();
                        XmlSerializer xmlSerializer = new XmlSerializer(i.GetType());
                        xmlSerializer.Serialize(xmlStream, i);
                        xmlStream.Position = 0;
                        tmpDoc.Load(xmlStream);
                    }
                    xmlOut.ImportNode(tmpDoc.DocumentElement.LastChild, true);
                }
               return xmlOut.InnerXml;
            }
