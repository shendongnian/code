    for (int i = 0; i < c.Count; i++)
            {
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(c[i].GetType());
                using (StringWriter writer = new StringWriter())
                {
                    x.Serialize(writer, c[i]);
                    String details = writer.ToString();
                }
                       //do here what ever you want
            } 
