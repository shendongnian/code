    //This event handler makes sure when a ListBoxItem is unselected
    // it automatically unselects all inner items
    private void myListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.RemovedItems != null)
            if (e.RemovedItems.Count > 0)
                foreach (var item in e.RemovedItems)
                {
                    if (item is MasterVm)
                        //implement this method
                        (item as MasterVm).UnselectAll();
                }
    }
    //This event handler makes sure that when datagrid row is Selected
    // it automatically selects listBoxItem
    private void DataGrid_Selected(object sender, RoutedEventArgs e)
    {
        var dg = sender as DataGridRow;
        var lbi = FindAncestor<ListBoxItem>(dg);
        lbi.IsSelected = true;
    }
