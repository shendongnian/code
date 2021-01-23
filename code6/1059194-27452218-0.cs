    TreeNode newNode=new TreeNode("SEARCH");
	AttributesTreeView.Nodes.Add(newNode);
	CreateTreeView(NewAttTree,newNode);
	
	public void CreateTreeView(DataTreeNode<string> root, TreeNode parentNode)
	{
	    foreach(DataTreeNode<string> node in root.Children)
		{
			try
			{
				TreeNode newNode=new TreeNode(node.Data.ToString());
				parentNode.Nodes.Add(newNode);
				CreateTreeView(node,newNode);
			}
			catch (System.Exception e)
			{
			}
		}
