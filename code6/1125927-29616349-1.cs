    public static class XObjectExtensions
    {
        public static string ToXml(this XElement xDoc)
        {
            using (TextWriter writer = new StringWriter())
            {
                xDoc.Save(writer);
                return writer.ToString();
            }
        }
    }
