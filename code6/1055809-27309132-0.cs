    void ExpandToLevel(TreeNodeCollection nodes, int level)
    {
        if (level > 0)
        {
            foreach (TreeNode node in nodes)
            {
                node.Expand();
                ExpandToLevel(node.Nodes, level - 1);
            }
        }
    }
