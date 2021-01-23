    private void DList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedDataObject = e.AddedItems[0]; // assuming single selection
        ListBoxItem selectedItem = 
            ListBoxName.ItemContainerGenerator.ContainerFromItem(selectedDataObject);
        selectedItem.Foreground = new SolidColorBrush(Colors.Red);
    }
