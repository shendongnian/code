    private void AddToTreeView(string domain, string link)
    {
        foreach (TreeNode node in treeView1.Nodes)
        {
            if (node.Text == domain)
            {
                node.Nodes.Add(link);
            }
        }
    }
