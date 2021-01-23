    TreeViewItem item = this.TreeView.ItemContainerGenerator.ContainerFromIndex(0) as TreeViewItem;
    if (item != null)
    {
        item.IsSelected = true;
        item.Focus();
    }
