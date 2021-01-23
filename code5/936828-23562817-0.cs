    [Fact]
    public void Test()
    {
        var root = XElement.Load("Data.xml");
        root.DescendantNodes()
            .Where(x => x.NodeType != XmlNodeType.Comment)
            .ToList()
            .ForEach(x => x.Remove());
        root.Save("Data.xml");
    }
