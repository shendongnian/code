    private static void PrintValues(JsonNodes nodes)
    {
        Console.WriteLine(string.Format("Node: {0}", nodes.Node));
        Console.WriteLine(string.Format("NodeValue: {0}", nodes.NodeValue));
        Console.WriteLine(string.Format("ParentNode: {0}", nodes.ParentNode));
        Console.WriteLine();
        foreach (JsonNodesAttribute attribute in nodes.Attributes)
        {
            Console.WriteLine(string.Format("Key: {0}", attribute.Key));
            Console.WriteLine(string.Format("Value: {0}", attribute.Value));
        }
        Console.WriteLine();
        foreach (JsonNodes childNode in nodes.Nodes)
        {
            PrintValues(childNode);
        }
    }
