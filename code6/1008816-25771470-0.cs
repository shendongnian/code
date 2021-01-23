    private void connecteditems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListViewItem item = (sender as ListView).SelectedItem;
            item.Foreground = new SolidColorBrush(Colors.Red);
        }
