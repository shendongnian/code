    using System.Xml.Linq;
    public class XmlParser
    {
        public XDocument doc { get; set;}
        
        public XmlParser (XDocument doc)
        {
            this.doc = doc;
        }
        public List<XElement> searchElements (String elementName)
        {
            return doc.Elements(elementName).ToList<XElement>(); //this will search for all child nodes and return the elements with the specified name.
        }
    }
