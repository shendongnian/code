    private IEnumerable<TreeViewModel> GetCheckedItems(TreeViewModel node)
    {
        var checkedItems = new List<TreeViewModel>();
        ProcessNode(node, checkedItems);
        return checkedItems;
    }    
    private void ProcessNode(TreeViewModel node, IEnumerable<TreeViewModel> checkedItems)
    {
        foreach (var child in node.Children)
        {
            if (child.IsChecked)
                checkedItems.Add(child);
            ProcessNode(child, checkedItems);
        }
    }
