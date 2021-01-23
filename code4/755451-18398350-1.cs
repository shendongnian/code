    TreeView TreeView1 = new TreeView();
    protected void Page_Load(object sender, EventArgs e)
    {
        BuildTree(@"C:\temp");
        form1.Controls.Add(TreeView1);
    }
    private void BuildTree(string root)
    {
        DirectoryInfo rootDir = new DirectoryInfo(root);
        TreeNode rootNode = new TreeNode(rootDir.Name, rootDir.FullName);
        TraverseTree(rootDir, TreeView1.Nodes);
    }
    private void TraverseTree(DirectoryInfo currentDir, TreeNodeCollection nodeCollection)
    {
        foreach (DirectoryInfo dir in currentDir.GetDirectories())
        {
            TreeNode node = new TreeNode(dir.Name, dir.FullName);
            nodeCollection.Add(node);                
            TraverseTree(dir, node.ChildNodes);
        }
        foreach (FileInfo file in currentDir.GetFiles())
        {
            TreeNode nodeFile = new TreeNode(file.Name, file.FullName);
            nodeCollection.Add(nodeFile);
        }
    }
