    private void checkBox_Click(object sender, RoutedEventArgs e)
    {
        foreach(var x in new ComboBoxItem[] { ItemBlue, ItemRed /*, etc*/ })
        {
            x.Visibility = checkBox.IsChecked.Value ? Visibility.Collapsed : Visibility.Visible;
         }
     }
