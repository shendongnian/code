    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {}
    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        cm.Visibility = cm.Visibility == Visibility.Collapsed
                            ? Visibility.Visible
                            : Visibility.Collapsed;
    }
