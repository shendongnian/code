    public object DeserializeXmlMyObj(String xml)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(MyObject));
                MyObject obj = null;
                using (StringReader reader = new StringReader(xml))
                {
                    obj = (MyObject)serializer.Deserialize(reader);
                }
                return obj ;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
