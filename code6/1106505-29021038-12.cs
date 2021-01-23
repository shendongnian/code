    public static class XmlNodeExtensions
    {
        public static bool IsDefaultNamespaceDeclaration(this XmlAttribute attr)
        {
            if (attr == null)
                return false;
            if (attr.NamespaceURI != "http://www.w3.org/2000/xmlns/")
                return false;
            return attr.Name == "xmlns";
        }
        public static bool IsNamespaceDeclaration(this XmlAttribute attr)
        {
            if (attr == null)
                return false;
            if (attr.NamespaceURI != "http://www.w3.org/2000/xmlns/")
                return false;
            return attr.Name == "xmlns" || attr.Name.StartsWith("xmlns:");
        }
    }
