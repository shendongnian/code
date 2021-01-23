    public TreeView ConvertNode(Node rootNode)
    {
        var tree = new TreeView
        {
            Id = rootNode.AutoIncrementId,
            Text = rootNode.Text,
            Items = new List<TreeView>()
        };
        if (rootNode.Nodes != null)
        {
            foreach (var node in rootNode.Nodes)
            {
                tree.Items.Add(ConvertNode(node));
            }
        }
        return tree;
    }
