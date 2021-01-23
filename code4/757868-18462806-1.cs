    private void checkBox_Click(object sender, RoutedEventArgs e)
    {
        itemBlue.Visibility = checkBox.IsChecked.Value ? Visibility.Collapsed : Visibility.Visible;
        itemRed.Visibility = checkBox.IsChecked.Value ? Visibility.Collapsed : Visibility.Visible;
    }
