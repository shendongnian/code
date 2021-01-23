    public class XmlValue
    {
        public System.Xml.Linq.XElement Element { get; set; }
        public string Text
        {
            get
            {
                if(Element == null) return null;
                return Element.Value;
            }
        }
    }
    public class XmlParser
    {
        public List<XmlValues> Getxml()
        {
            XDocument xdoc = XDocument.Load(@"D:\Web Utf-8 Converter\Categories.xml");
            var list = (from p in xdoc.Descendants("Categories")
                select new XmlValue { Element = p.Elements("name")});
            var listing = list.ToList();
            return listing;
        }
    }
