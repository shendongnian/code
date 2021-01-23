    private static void PrintValues(JsonNodes nodes, string parent)
    {
        Console.WriteLine(string.Format("Name: {0}", nodes.Node));
        Console.WriteLine(string.Format("Value: {0}", nodes.NodeValue));
        Console.WriteLine("IsNode: true");
        Console.WriteLine(string.Format("Parent: {0}", parent)); 
        Console.WriteLine();
        if (parent == string.Empty)
        {
            parent += nodes.Node;
        }
        else
        {
            parent += string.Format("/{0}", nodes.Node);
        }
        foreach (JsonNodesAttribute attribute in nodes.Attributes)
        {
            Console.WriteLine(string.Format("Name: {0}", attribute.Key));
            Console.WriteLine(string.Format("Value: {0}", attribute.Value));
            Console.WriteLine("IsNode: false");
            Console.WriteLine(string.Format("Parent: {0}", parent));
        }
        Console.WriteLine();
        foreach (JsonNodes childNode in nodes.Nodes)
        {
            PrintValues(childNode, parent);
        }
    }
