    public static class MyLinqToXmlExtensions
    {
        public static IEnumerable<XElement> ForAncestorsAndSelf(this XElement e, XName name)
        {
            return name == null ? e.AncestorsAndSelf() : e.AncestorsAndSelf(name);
        }
    };
