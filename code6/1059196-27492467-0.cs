    bool PopulateTreeNode(DataTreeNode<string> dataNode,TreeNode treeNodes,string filter,bool ignoreCase)
		{
			if(dataNode.IsLeaf)
			{
				if(WcMatchExtensionMethods.WcMatches(dataNode.Data,filter,ignoreCase))
				{
					treeNodes.Nodes.Add(new TreeNode(dataNode.Data.ToString()));
					return true;
				}
				else
					return false;
			}
			bool result = false;
			TreeNode treeNode=new TreeNode(dataNode.Data.ToString());
			foreach (DataTreeNode<string> child in dataNode.Children)
			{
				if(PopulateTreeNode(child,treeNode,filter,ignoreCase))
				{
					treeNodes.Nodes.Add(treeNode);
					result = true;
				}
			}
			return result;
		}
