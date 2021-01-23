    private void Xml2TreeNode(XElement xNode, TreeNode treeNode)
    {
    	if (xNode.HasElements) //if node has children
    	{
    		TreeNode tNode = null;
    		int i = 0;
    		foreach (XElement subNode in xNode.Elements())
    		{
    			if (subNode.Descendants().Count() > 0)
    			{//handle non-leaf node
    				TreeNode tn = treeNode.Nodes.Add(subNode.Name.ToString().Trim());
    				tn.Nodes.Add(new TreeNode(subNode.FirstNode.ToString().Trim()));
    				tn.Tag = treeNode.Nodes[i].Tag = subNode.Attributes().ToList(); //---->these values are retrived in SaveNodes function
    				tNode = tn; //add child nodes
    			}
    			else
    			{//handle leaf node
    				TreeNode tn = treeNode.Nodes.Add(subNode.Name.ToString().Trim()); //show name of a leaf node element
    				tn.Nodes.Add(new TreeNode(subNode.Value.ToString().Trim())); //show value of above element as a child of its name
    				tn.Tag = treeNode.Nodes[i].Tag = subNode.Attributes().ToList(); //---->these values are retrived in SaveNodes function
    				tNode = treeNode.Nodes[i++]; //add sibling node
    			}
    
    			Xml2TreeNode(subNode, tNode); //recursively add child nodes
    		}
    	}
    }  
  
  
    private void Xml2TreeNode(XElement xNode, TreeNode treeNode)
    {
        if (xNode.HasElements) //if node has children
        {
            TreeNode tNode = null;
            int i = 0;
            foreach (XElement subNode in xNode.Elements())
            {
                if (subNode.Descendants().Count() > 0)
                {//handle non-leaf node
                    TreeNode tn = treeNode.Nodes.Add(subNode.Name.ToString().Trim());
                    ////tn.Nodes.Add(new TreeNode(subNode.FirstNode.ToString().Trim())); //adds extra element-value to node
                    tn.Tag = treeNode.Nodes[i].Tag = subNode.Attributes().ToList(); //---->these values are retrived in TreeNode2Xml function
                    tNode = tn; //add child nodes
                }
                else
                {//handle leaf node
                    TreeNode tn = treeNode.Nodes.Add(subNode.Name.ToString().Trim()); //show name of a leaf node element
                    tn.Nodes.Add(new TreeNode(subNode.Value.ToString().Trim())); //show value of above element as a child of its name
                    tn.Tag = treeNode.Nodes[i].Tag = subNode.Attributes().ToList(); //---->these values are retrived in TreeNode2Xml function
                    tNode = treeNode.Nodes[i++]; //add sibling node
                }
                Xml2TreeNode(subNode, tNode); //recursively add child nodes
            }
        }
    }
