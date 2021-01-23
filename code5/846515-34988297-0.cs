    // usage
    SelectNodeByValue(treMain.Nodes, "1");
        
    // recursive function:
    protected void SelectNodeByValue(TreeNodeCollection Nodes, string ValueToSelect)
    {
        foreach (TreeNode n in Nodes)
        {
            if (n.Value == ValueToSelect)
                n.Select();
            else if (n.ChildNodes.Count > 0)
                SelectNodeByValue(n.ChildNodes, ValueToSelect);
        }
    }
