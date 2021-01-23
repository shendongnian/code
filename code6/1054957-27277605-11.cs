    void OutputNodes(IEnumerable<TreeNode> nodes, int indentLevel)
    {
        foreach (var node in nodes)
        {
            // output the node
            // do indentation here
            Console.WriteLine(node.Name);
            // and then the children
            var orderedChildren = node.Children.OrderBy(n -> n.SeqID);
            OutputNodes(orderedChildren, indentLevel + 1);
        }
    }
