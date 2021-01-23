    private void PopulateTree(ListObjectsResponse buckets)
    {
        var selectedText = treeView1.SelectedNode.Text;
        treeView1.Nodes.Clear();
        treeView1.Nodes.AddRange(buckets.S3Objects.Select(o => new TreeNode(o.Key)))
        treeView1.SelectedNode =
            = treeView1.Nodes.Cast<TreeNode>().SingleOrDefault(n => n.Text == selectedText);
    }
