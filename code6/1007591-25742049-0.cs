    bool suppressClick = false;
    private void treeView1_Click(object sender, EventArgs e)
    {
        if (suppressClick) return;
        // else your regular code..
    }
    private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        if (e.Node.IsExpanded)
             { suppressClick = false; }
        else { suppressClick = true; }
    }
