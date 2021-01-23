    private void ListView_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
    {
       var listView = sender as ListView;
       var selectedItems = listView.SelectedItems;
       // looping all selected items
       for(var i in selectedItems)
       {
           // do whatever you want
       }
    }
