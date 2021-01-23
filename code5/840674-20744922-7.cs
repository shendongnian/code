    private void TreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        var item = (TreeItemObject)e.NewValue;
        if ((item != null) && (item.Parent != null) && (item.Parent.IsAlive))
        {
            // do stuff - Console.WriteLine(((Connection)item.Parent.Target).DisplayName);
        }
    }
