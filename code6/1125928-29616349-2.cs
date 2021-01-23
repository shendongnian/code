    public static class XObjectExtensions
    {
        public static string ToXml(this XDocument xDoc)
        {
            using (var writer = new StringWriter())
            {
                xDoc.Save(writer);
                return writer.ToString();
            }
        }
    }
