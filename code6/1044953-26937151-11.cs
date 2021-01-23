    private void Button_Click(object sender, RoutedEventArgs e)
    {
        //var item = ListItemsControl.ItemContainerGenerator.ContainerFromIndex(1) as ListBoxItem;
        //var innerListBox = VisualTreeHelper.GetChild(item, 0) as ListBox;
        //innerListBox.SelectedIndex++;
        // For every item in the ListItemsControl
        for (int i = 0; i < ListItemsControl.Items.Count; i++)
        {
            // Get the item container for the specified index and cast it as ListBoxItem.
            var item = ListItemsControl.ItemContainerGenerator.ContainerFromIndex(i) 
                as ListBoxItem;
            // Then, get the first child of the ListBoxItem and cast it as a ListBox.
            // Note that I'm making an assumption that it'll always be a ListBox,
            // which is why you should perform some checks in a production case,
            // to avoid exceptions.
            var innerListBox = VisualTreeHelper.GetChild(item, 0) as ListBox;
            // Lastly, I increment the index of this ListBox.
            innerListBox.SelectedIndex++;
        }
    }
