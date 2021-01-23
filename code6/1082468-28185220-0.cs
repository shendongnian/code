        public static string ToXml(this XmlDocument xDoc)
        {
            StringBuilder builder = new StringBuilder();
            using (TextWriter writer = new StringWriter(builder))
            {
                xDoc.Save(writer);
                return builder.ToString();
            }
        }
