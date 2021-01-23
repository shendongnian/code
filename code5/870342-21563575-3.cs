    private void publicationsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ListBox listBox = (ListBox)sender;
        Grid selectedGrid = (Grid)listBox.SelectedItem;
        Publication selectedItem = (Publication)selectedGrid.DataContext;
        ...
    }
