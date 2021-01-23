    public TreeNode previousSelectedNode = null;
    private void treeView1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
        treeView1.SelectedNode.BackColor = SystemColors.Highlight;
        treeView1.SelectedNode.ForeColor = Color.White;
        previousSelectedNode = treeView1.SelectedNode;
    }
    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
        if(previousSelectedNode != null)
        {
            previousSelectedNode.BackColor = treeView1.BackColor;
            previousSelectedNode.ForeColor = treeView1.ForeColor;
        }
    }
