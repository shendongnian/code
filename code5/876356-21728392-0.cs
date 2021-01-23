    private void yourTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        if (sender is TreeView && ((TreeViewItem)((TreeView)sender).SelectedItem).Parent != null)
        {
            TreeViewItem parent = (TreeViewItem)((TreeViewItem)((TreeView)sender).SelectedItem).Parent;  // This will give you the parent             
        }
    }
