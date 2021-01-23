    public void OnClick( object sender, RoutedEventArgs args )
    {
        Image1.Visibility = Image1.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        Image2.Visibility = Image2.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        Image3.Visibility = Image3.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
    }
