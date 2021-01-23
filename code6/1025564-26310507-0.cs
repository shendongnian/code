    private void CollapseChildren(RectangleTreeNode node)
    {
        if (node.Children == null)
        {
            // exit the method, or do whatever is appropriate when node.Children is null
            return;
        }
        foreach (RectangleTreeNode child in node.Children)
        {
            if (child == null)
            {
                return;
            }
            while (child.Items.Count > 0)
            {
                MoveUp(child.Items[0]);
            }
        }
        node.Children = null;
    }
