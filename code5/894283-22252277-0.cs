    public static class TreeViewEx
    {
    	public static List<TreeNode> GetAllParentNodes(this TreeView treeView)
    	{
    		List<TreeNode> list = new List<TreeNode>();
    		List<TreeNode> retList = new List<TreeNode>();
    		foreach (TreeNode node in treeView.Nodes)
    		{
    			list.Add(node);
    			foreach (TreeNode n in node.Nodes)
    				list.AddRange(GetAllNodes(n));
    		}
    		foreach (TreeNode n in list)
    		{
    			if (n.Nodes.Count > 0)
    				retList.Add(n);
    		}
    		return retList;
    	}
    	public static List<TreeNode> GetAllNodes(this TreeNode Node)
    	{
    		List<TreeNode> list = new List<TreeNode>();
    		list.Add(Node);
    		foreach (TreeNode n in Node.Nodes)
    			list.AddRange(GetAllNodes(n));
    		return list;
    	}
    }
