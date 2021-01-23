    private void PopulateTree(ListObjectsResponse buckets)
    {
        // Since you're about to clear out all current TreeNode instances, storing a
        // reference to SelectedNode is not enough. You're setting o.Key as the Text
        // for each TreeNode, so save the selected node's Text value. 
        var selectedText
            = treeView1.SelectedNode == null ? "" : treeView1.SelectedNode.Text;
        // Repopulate your TreeView with new TreeNodes
        treeView1.Nodes.Clear();
        treeView1.Nodes.AddRange(buckets.S3Objects.Select(o => new TreeNode(o.Key)).ToArray())
        // Look for the TreeNode with the same Text that you had selected before.
        // If it's not found, then SelectedNode will be set to null
        treeView1.SelectedNode =
            = treeView1.Nodes.Cast<TreeNode>()
                             .SingleOrDefault(n => n.Text == selectedText);
    }
