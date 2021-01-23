    private void SelectParents(TreeNode node, Boolean isChecked)
    {
        var parent = node.Parent;
    
        if (parent == null)
            return;
    
        if (isChecked)
        {
            parent.Checked = true; // we should always check parent
            SelectParents(parent, true);
        }
        else
        {
            if (parent.Nodes.Cast<TreeNode>().Any(n => n.Checked))
                return; // do not uncheck parent if there other checked nodes
            SelectParents(parent, false); // otherwise uncheck parent
        }
    }
