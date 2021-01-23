    private static void TraverseTreeNode(TreeNodeCollection nodes, int level)
    {
        var numberOfChildren = 1;
        foreach (TreeNode node in nodes)
        {
            node.Value = string.Format("{0}{1}", level, numberOfChildren ).Substring(0,node.Depth+1);
            TraverseTreeNode(node.ChildNodes, level);
            numberOfChildren++;
            if (node.Depth == 0) { level++; }
        }
    }
