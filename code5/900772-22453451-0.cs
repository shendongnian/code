    public static void SerializeXMLData(string pth, object xmlobj)
        {
            XmlSerializer serializer = new XmlSerializer(xmlobj.GetType());
            using (XmlTextWriter tw = new XmlTextWriter(pth, Encoding.UTF8))
            {
                tw.Formatting = Formatting.Indented;
                serializer.Serialize(tw, xmlobj);
            }
        }
