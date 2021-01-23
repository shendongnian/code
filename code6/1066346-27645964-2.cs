    private void GetNodesText(TreeNodeCollection tnc, List<string> selectednodes)
    {
        foreach (TreeNode node in tnc)
        {
            if (node.Nodes.Count > 0)
                GetNodesText(node.Nodes, selectednodes);
            if (node.Checked)
                selectednodes.Add(node.Text);
        }
    }
