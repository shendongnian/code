    public void PopulateTree(string dir, TreeNode node)
    {
    	DirectoryInfo directory = new DirectoryInfo(dir);
    	foreach (DirectoryInfo d in directory.GetDirectories())
    	{
    		TreeNode t = new TreeNode(d.Name);
    		if (node != null) node.Nodes.Add(t);
    		else treeView1.Nodes.Add(t);
    		PopulateTree(d.FullName, t);      
    	}
    	foreach (FileInfo f in directory.GetFiles())
    	{
    		TreeNode t = new TreeNode(f.Name);
    		if (node != null) node.Nodes.Add(t);
    		else treeView1.Nodes.Add(t);
    	}
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
    	PopulateTree(@"C:\treeview", null);
    }
