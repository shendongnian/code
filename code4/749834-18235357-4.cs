    private void SelectParents(TreeNode node, Boolean isChecked)
    {
        var parent = node.Parent;
        if (parent == null)
            return;
        
        if (!isChecked && HasCheckedNode(parent))
            return;
        parent.Checked = isChecked;
        SelectParents(parent, isChecked);
    }
    private bool HasCheckedNode(TreeNode node)
    {
        return node.Nodes.Cast<TreeNode>().Any(n => n.Checked);
    }
