    public static class XmlNodeExtensions
    {
        public static bool IsNamespaceDeclaration(this XmlAttribute attr)
        {
            if (attr == null)
                return false;
            return attr.Name == "xmlns" || attr.Name.StartsWith("xmlns:");
        }
    }
