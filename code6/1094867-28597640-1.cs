    private TreeNode selectedNode = null;
    private void button3_Click(object sender, EventArgs e)
    {
        MessageBox.Show(selectedNode.Text);
    }
    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
        selectedNode = e.Node;
    }
