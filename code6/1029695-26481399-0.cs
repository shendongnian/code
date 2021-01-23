    public class XmlAttributesIntComparer : IComparer<string>
    {
        private readonly string elementName;
        public XmlAttributesIntComparer(string elementName)
        {
            this.elementName = elementName;
        }
        public int Compare(string x, string y)
        {
            XmlDocument doc1 = new XmlDocument();
            doc1.LoadXml(x);
            XmlDocument doc2 = new XmlDocument();
            doc2.LoadXml(y);
            XmlText text1 = (XmlText)doc1.DocumentElement[elementName].FirstChild;
            XmlText text2 = (XmlText)doc2.DocumentElement[elementName].FirstChild;
            int attr1 = Convert.ToInt32(text1.Value);
            int attr2 = Convert.ToInt32(text2.Value);
            return attr1.CompareTo(attr2);
        }
    }
    // ...
    listOfXML.Sort(new XmlAttributesIntComparer("ThirdAttribute"));
