        public static void RemoveNamespace(this XElement element)
        {
            foreach (XElement e in element.DescendantsAndSelf())
            {
                if (e.Name.Namespace != XNamespace.None)
                    e.Name = e.Name.LocalName;
                if (e.Attributes().Any(a => a.IsNamespaceDeclaration || a.Name.Namespace != XNamespace.None))
                    e.ReplaceAttributes(e.Attributes().Select(NoNamespaceAttribute));
            }
        }
        private static XAttribute NoNamespaceAttribute(XAttribute attribute)
        {
            return attribute.IsNamespaceDeclaration
                ? null
                : attribute.Name.Namespace != XNamespace.None
                    ? new XAttribute(attribute.Name.LocalName, attribute.Value)
                    : attribute;
        }
