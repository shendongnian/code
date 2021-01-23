    private void publicationsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // Get the currently selected item from the ListBox
        ListBox listBox = (ListBox)sender;
        Publication selectedItem = (Publication)listBox.SelectedItem;
        // Or you can just do this without the ListBox reference
        selectedItem = (Publication)e.AddedItems[0]);
        ...
    }
