        public static string ToXml(this XDocument xDoc)
        {
            StringBuilder builder = new StringBuilder();
            using (TextWriter writer = new StringWriter(builder))
            {
                xDoc.Save(writer);
                return builder.ToString();
            }
        }
