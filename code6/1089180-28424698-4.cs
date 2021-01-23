    public static class XmlSerializationHelper
    {
        public static string ToXml(this XDocument xDoc)
        {
            using (TextWriter writer = new StringWriter())
            {
                xDoc.Save(writer);
                return writer.ToString();
            }
        }
    }
