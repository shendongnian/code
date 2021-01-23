    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
                ""jcr:type"" : ""nt:file"",
                ""jcr:content"" : [""jcr:uuid"", ""jfkjsaf""]
            }";
            XmlDocument xdoc = JsonConvert.DeserializeXmlNode(json, "root");
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            using (XmlTextWriter writer = new XmlTextWriter(sw))
            {
                writer.Formatting = System.Xml.Formatting.Indented;
                xdoc.WriteTo(writer);
            }
            Console.WriteLine(sb.ToString());
        }
    }
