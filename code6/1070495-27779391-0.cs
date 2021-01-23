    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        myTextBox.IsTabStop = false;
        Button1.Visibility = Visibility.Collapsed;
        myTextBox.IsTabStop = true;
    }
