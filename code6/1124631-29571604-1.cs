    public static class XmlNodeExtensions
    {
        public static IEnumerable<XmlNode> AncestorsAndSelf(this XmlNode node)
        {
            for (; node != null; node = node.ParentNode)
                yield return node;
        }
    }
