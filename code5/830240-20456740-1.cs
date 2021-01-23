    private void ListItemsToday_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = ListItemsToday.SelectedItem as TodoItem;
        MessageBox.Show(item.Text);
    }
