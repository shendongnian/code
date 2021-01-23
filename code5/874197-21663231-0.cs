    public void PopulateRoot(string dir, TreeNodeCollection nodes)
    {
        DirectoryInfo directory = new DirectoryInfo(dir);
        foreach (DirectoryInfo d in directory.GetDirectories())
        {
            TreeNode t = new TreeNode(d.Name);
            PopulateTree(d.FullName, t);
            nodes.Add(t);
        }
        foreach (FileInfo f in directory.GetFiles())
        {
            TreeNode t = new TreeNode(f.Name);
            nodes.Add(t);
        }
    }
