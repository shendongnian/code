    private void publicationsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ListBox listBox = (ListBox)sender;
        Publication selectedItem = (Publication)e.AddedItems[0]);
        ...
    }
