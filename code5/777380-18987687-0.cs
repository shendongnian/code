    private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
    {
       Node parent = e.Node.Parent;
       string i = parent == null ? "No parent" : parent.Index;
       listView1.Items.Add(string.Format("{0}:{1}",i,e.Node.Index);
    }
