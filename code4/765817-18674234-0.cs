    TreeNode n = null;
    TreeNode parent = null;
    foreach(string s in SplittedString)
    {
        if (parent == null)
        {
            parent = new TreeNode(s);
            treeview1.Nodes.Add(parent);
            continue;
        }
    
        n = new TreeNode(s);
        parent.Nodes.Add(n);
        parent = n;
    }
