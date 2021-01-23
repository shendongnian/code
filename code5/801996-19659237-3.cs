    public static IEnumerable<TreeNode> GetNodesByDepth(TreeView treeView, int depth)
    {
        var nodes = treeView.Nodes.Cast<TreeNode>();
        for (int i=0; i < depth; i++)
            nodes = nodes.SelectMany(n => n.Nodes).Cast<TreeNode>();
        return nodes;
    }
