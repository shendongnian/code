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
        //TreeView1.Nodes.Add(rootNode);
        TraverseTree(rootDir, null);
    }
    private void TraverseTree(DirectoryInfo currentDir, TreeNode currentNode)
    {
        foreach (DirectoryInfo dir in currentDir.GetDirectories())
        {
            TreeNode node = new TreeNode(dir.Name, dir.FullName);
			AddToNode(currentNode, node);			
            TraverseTree(dir, node);
        }
        foreach (FileInfo file in currentDir.GetFiles())
        {
            TreeNode nodeFile = new TreeNode(file.Name, file.FullName);
            AddToNode(currentNode, nodeFile);
        }
    }
	private void AddToNode (TreeNode parentNode, TreeNode childNode)
	{
		if (parentNode != null)
		{
			parentNode.ChildNodes.Add(childNode);
		}
		else
		{
			TreeView1.Nodes.Add(childNode);
		}
	}
