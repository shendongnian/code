    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        Image img = new Image();
        img.RenderSize = new Size(30,30);
        img.OpacityMask = Brushes.CadetBlue;
        _Friends = new List<Friend> {
            new Friend{Name="John Smith", IsOnline=true, Image=img},
            new Friend{Name="Name Surname", IsOnline=true, Image=img},
            new Friend{Name="Name2 surname2", IsOnline=false, Image=img}
        };
        OnlineItemsControl.ItemsSource = _Friends;
    }
