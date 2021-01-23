    internal class Program
    {
        private static void Main(string[] args)
        {
            var xml = "<double>0.7423</double>";
            Debug.WriteLine("Method1: {0}", Method1(xml));
            Debug.WriteLine("Method2: {0}", Method2(xml));
            Debug.WriteLine("Method3: {0}", Method3(xml));
        }
        private static double Method1(string xml)
        {
            var xdoc = XDocument.Parse(xml);
            var doubleStr = xdoc.Root.Value;
            var doubleValue = double.Parse(doubleStr, CultureInfo.InvariantCulture);
            return doubleValue;
        }
        private static double Method2(string xml)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            return double.Parse(xmlDoc.FirstChild.InnerText, CultureInfo.InvariantCulture);
        }
        private static double Method3(string xml)
        {
            var doubleStr = xml.Substring(
                xml.IndexOf(">") + 1,
                xml.IndexOf("</") - xml.IndexOf(">") - 1
                );
            return double.Parse(doubleStr, CultureInfo.InvariantCulture);
        }
    }
