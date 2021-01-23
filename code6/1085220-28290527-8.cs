    public static class XmlNodeExtensions
    {
        public static IEnumerable<XmlElement> ChildElements(this IEnumerable<XmlElement> elements)
        {
            return elements.SelectMany(e => e.ChildNodes.OfType<XmlElement>());
        }
        public static IEnumerable<XmlElement> OfLocalName(this IEnumerable<XmlElement> elements, string localName)
        {
            return elements.Where(e => e.LocalName == localName);
        }
    }
