    private void TreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        var treeView = sender as TreeView;
        var item = treeView.SelectedItem as TreeItemObject;
        if (item.Parent.IsAlive)
        {
            var parent = item.Parent.Target;
        }
    }
