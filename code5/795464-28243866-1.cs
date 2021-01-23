    private TreeNode[] GetTreeViewNodes(IList<TreeViewNode> nodes)
    {
        IList<TreeNode> returnedNodes = new List<TreeNode>();
        foreach (var item in nodes)
        {
            TreeNode node = new TreeNode(item.Text, this.GetTreeViewNodes(item.Children));
            node.Tag = item.DocKey;
            returnedNodes.Add(node);
        }
    
        return returnedNodes.ToArray();
    }
