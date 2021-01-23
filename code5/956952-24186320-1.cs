    // I'm assuming we don't mind too much about the ordering...
    public static IEnumerable<XmlElement> DescendantsAndSelf(this XmlElement node)
    {
        return new[] { node }.Concat(node.ChildNodes
                                         .OfType<XmlElement>()
                                         .SelectMany(x => x.DescendantsAndSelf()));
    }
