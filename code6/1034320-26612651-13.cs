    void setRows()
    {
        foreach (SBBTreeNode<string> node in flatTree)
        {
            if (node.Left != null)  node.Left.Row = node.Row + 1;
            if (node.Right != null) node.Right.Row = 
                                    node.Row + 1 - (node.Right.IsHorizontal ? 1:0);
        }
    }
