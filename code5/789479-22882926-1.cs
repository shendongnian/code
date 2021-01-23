    var pp = new Pushpin
    {
        Background = cObject.Bcolor,
        GeoCoordinate = cObject.Coordinate,
        Content = ppIc.Convert(cObject.Name, typeof (BitmapImage), null, CultureInfo.CurrentUICulture),
        DataContext = cObject,
        Template = this.Resources["PinTemplate"] as ControlTemplate
    };
    pp.Tap += UIElement_OnTap;
    
    var overlay = new MapOverlay
    {
        Content = pp,
        GeoCoordinate = pp.GeoCoordinate
    };
    _pushpinLayer.Add(overlay);
