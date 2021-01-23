    private void icDists_Loaded(object sender, RoutedEventArgs e)
    {
        // get the container for the first index
        var item = this.icDists.ItemContainerGenerator.ContainerFromIndex(0);
        // var item = this.icDists.ItemContainerGenerator.ContainerFromItem(item_object); // you can also get it from an item if you pass the item in the ItemsSource correctly
        // find the DataGrid for the first container
        DataGrid dg = FindFirstElementInVisualTree<DataGrid>(item);
        // at this point dg should be the DataGrid of the first item in your list
    }
