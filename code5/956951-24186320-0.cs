    // I'm assuming we don't mind too much about the ordering...
    public static IEnumerable<XmlElement> DescendantsAndSelf(this XmlElement node)
    {
        return node.ChildNodes
                   .OfType<XmlElement>()
                   .SelectMany(x => new[] { x }.Concat(x.Descendants());
    }
