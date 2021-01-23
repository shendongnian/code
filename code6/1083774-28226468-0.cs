    public void AddPushpin(BasicGeoposition location, string text)
    {
        #if WINDOWS_APP
        var pin = new Pushpin()
        {
            Text = text
        };
        MapLayer.SetPosition(pin, location.ToLocation());
        _pinLayer.Children.Add(pin);
        #elif WINDOWS_PHONE_APP
        var pin = new Grid()
        {
            Width = 24,
            Height = 24,
            Margin = new Windows.UI.Xaml.Thickness(-12)
        };
    
        pin.Children.Add(new Ellipse()
        {
            Fill = new SolidColorBrush(Colors.DodgerBlue),
            Stroke = new SolidColorBrush(Colors.White),
            StrokeThickness = 3,
            Width = 24,
            Height = 24
        });
    
        pin.Children.Add(new TextBlock()
        {
            Text = text,
            FontSize = 12,
            Foreground = new SolidColorBrush(Colors.White),
            HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center,
            VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Center
        });
    
        MapControl.SetLocation(pin, new Geopoint(location));
        _map.Children.Add(pin);
        #endif
    }
