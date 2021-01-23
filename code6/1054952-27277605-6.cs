    void OutputNodes(IEnumerable<TreeNode> nodes)
    {
        foreach (var node in nodes)
        {
            // output the node
            Console.WriteLine(node.Name);
            // and then the children
            var orderedChildren = node.Children.OrderBy(n -> n.SeqID);
            OutputNodes(orderedChildren);
        }
    }
