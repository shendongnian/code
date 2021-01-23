    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            XmlTextWriter writer = new XmlTextWriter(sw);
            string xmlns = "http://james.newtonking.com/projects/json";
            writer.Formatting = System.Xml.Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("result");
            writer.WriteAttributeString("xmlns", "json", null, xmlns);
            writer.WriteStartElement("object");
            writer.WriteAttributeString("Array", xmlns, "true");
            writer.WriteStartElement("foo");
            writer.WriteString("bar");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            string xml = sb.ToString();
            Console.WriteLine(xml);
            Console.WriteLine();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string json = JsonConvert.SerializeXmlNode(doc, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
