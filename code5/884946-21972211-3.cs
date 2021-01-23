    private void Button_Click(object sender, RoutedEventArgs e)
    {
        ListBoxItem selectedItem = (ListBoxItem)listBox.ItemContainerGenerator.
                                   ContainerFromItem(((Button)sender).DataContext);
        selectedItem.IsSelected = true;
    }
