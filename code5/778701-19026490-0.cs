    public void treeView1_NodeMouseDoubleClick(Object sender, TreeNodeMouseClickEventArgs e)
    {
        foreach (TreeNode node in e.Node.Parent.Nodes)
        {
            if (node != e.Node)
                treeView1.CollapseAll();
    
        }
    }
