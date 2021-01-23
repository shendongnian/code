    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (descbox.Visibility == Visibility.Visible)
            descbox.Visibility = Visibility.Collapsed;
        else
            descbox.Visibility = Visibility.Visible;
    }
