      PopulateTree(@"C:\treeview", treeView1.Nodes);
    public void PopulateTree(string dir, TreeNodeCollection nodes)
    {
        DirectoryInfo directory = new DirectoryInfo(dir);
        foreach (DirectoryInfo d in directory.GetDirectories())
        {
            TreeNode t = new TreeNode(d.Name);
            nodes.Add(t);
            PopulateTree(d.FullName, t.Nodes);            
        }
        foreach (FileInfo f in directory.GetFiles())
        {
            TreeNode t = new TreeNode(f.Name);
            nodes.Add(t);
        }
    }
