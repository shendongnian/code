    if (treeViewMS1.CheckedNodes.Count > 0)
    {
        List<string> _selectednodes = new List<string>();
        foreach (TreeNode node in treeViewMS1.CheckedNodes)
        {
            if(node.Parent != null)
            {
                string checkedValue = node.Text.ToString();
                _selectednodes.Add(checkedValue);
            }
        }
    }
