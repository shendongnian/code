    private TreeViewItem FindParentTreeViewItem(object child)
    {
        try
        {
            var parent = VisualTreeHelper.GetParent(child as DependencyObject);
            while ((parent as TreeViewItem) == null)
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            return parent as TreeViewItem;
        }
        catch (Exception e)
        {
            //could not find a parent of type TreeViewItem
            return null;
        }
    }
                
