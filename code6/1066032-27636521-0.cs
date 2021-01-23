    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
    	ExpandOrCollapseToLevel(treeView1.Nodes, (int)numericUpDown1.Value);
    }
    
    void ExpandOrCollapseToLevel(TreeNodeCollection nodes, int level)
    {
    	foreach (TreeNode node in nodes)
    	{
    		if (level > 0)
    			node.Expand();
    		else
    			node.Collapse();
    		ExpandToLevel(node.Nodes, level - 1);
    	}
    }
