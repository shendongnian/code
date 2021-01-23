    private void TreeViewItem_Expanded(object sender, RoutedEventArgs e)
    {
    	TreeViewItem treeViewItem = e.OriginalSource as TreeViewItem;
    	if (treeViewItem != null)
    	{
    		BaseObjectExplorerNode baseObjectExplorerNode = treeViewItem.Header as BaseObjectExplorerNode;
    		if (baseObjectExplorerNode != null)
    		{
    			baseObjectExplorerNode.IsExpanded = true;
    		}
    	}
    }
    private void TreeViewItem_Collapsed(object sender, RoutedEventArgs e)
    {
    	TreeViewItem treeViewItem = e.OriginalSource as TreeViewItem;
    	if (treeViewItem != null)
    	{
    		BaseObjectExplorerNode baseObjectExplorerNode = treeViewItem.Header as BaseObjectExplorerNode;
    		if (baseObjectExplorerNode != null)
    		{
    			baseObjectExplorerNode.IsExpanded = false;
    		}
    	}
    }
