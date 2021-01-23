    private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
    {
        if (e.Node.Text == "AreaCode")
        {
            foreach (TreeNode childNode in e.Node.Nodes)
            {
                childNode.Checked = e.Node.Checked;
            }
        }
    }
