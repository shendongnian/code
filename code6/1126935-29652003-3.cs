    private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
    {
        // Any node that is checked/unchecked will have all of its 
        // children nodes checked/unchecked
        if (e.Node.Nodes.Count > 0)
        {
            foreach (TreeNode childNode in e.Node.Nodes)
            {
                childNode.Checked = e.Node.Checked;
            }
        }
    }
