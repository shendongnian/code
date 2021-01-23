    private void Button_Click(object sender, RoutedEventArgs e)
    {
        //var item = ListItemsControl.ItemContainerGenerator.ContainerFromIndex(1) as ListBoxItem;
        //var innerListBox = VisualTreeHelper.GetChild(item, 0) as ListBox;
        //innerListBox.SelectedIndex++;
        for (int i = 0; i < ListItemsControl.Items.Count; i++)
        {
            var item = ListItemsControl.ItemContainerGenerator.ContainerFromIndex(i) 
                as ListBoxItem;
            var innerListBox = VisualTreeHelper.GetChild(item, 0) as ListBox;
            innerListBox.SelectedIndex++;
        }
    }
