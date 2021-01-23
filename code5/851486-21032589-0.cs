    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ListBoxItem listBoxItem = (ListBoxItem)e.AddedItems[0];
        listBoxItem.PreviewMouseDoubleClick += ListBoxItem_PreviewMouseDoubleClick;
        listBoxItem = (ListBoxItem)e.RemovedItems[0];
        listBoxItem.PreviewMouseDoubleClick -= ListBoxItem_PreviewMouseDoubleClick;
    }
    private void ListBoxItem_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        // Selected item was double clicked
    }
