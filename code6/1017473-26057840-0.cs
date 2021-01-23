        static int GetInt32(SqlXml sqlXml)
        {
            int value;
            // using System.Xml;
            using (XmlReader xmlReader = sqlXml.CreateReader())
            {
                // using System.Xml.Serialization;
                XmlSerializer xmlSerializer = new XmlSerializer(typeof (int));
                value = (int) xmlSerializer.Deserialize(xmlReader);
            }
            return value;
        }
