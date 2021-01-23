    static void Main(string[] args)
    {
        var xml = @"
    <rootNode>
        <foo enabled=""true"">
             <bar enabled=""false"" myAttribute=""5.6"" />
             <baz>Text!</baz>
        </foo>
    </rootNode>
    ";
        var document = new XmlDocument();
        document.LoadXml(xml);
        var retVal = new Dictionary<string, string>();
        Go(retVal, document.DocumentElement, new List<string>());
    }
    private static void Go(Dictionary<string, string> theDict, XmlElement start, List<string> keyTokens)
    {
        // Process simple content
        var textNode = start.ChildNodes.OfType<XmlText>().SingleOrDefault();
        if (textNode != null)
        {
            theDict[string.Join(".", keyTokens.ToArray())] = textNode.Value;
        }
        // Process attributes
        foreach (XmlAttribute att in start.Attributes)
        {
            theDict[string.Join(".", keyTokens.ToArray()) + "." + att.Name] = att.Value;
        }
        // Process child nodes
        foreach (var childNode in start.ChildNodes.OfType<XmlElement>())
        {
            Go(theDict, childNode, new List<string>(keyTokens) { childNode.Name });   // shorthand for .Add
        }
    }
