    public MapView()
    {           
        #if WINDOWS_APP
        _map = new Map();
    
        _shapeLayer = new MapShapeLayer();
        _map.ShapeLayers.Add(_shapeLayer);
    
        _pinLayer = new MapLayer();
        _map.Children.Add(_pinLayer);
        _map.PointerPressedOverride += _map_PointerPressedOverride;
        #elif WINDOWS_PHONE_APP
        _map = new MapControl();
        _map.PointerPressed += _map_PointerPressed;
        #endif
    
        this.Children.Add(_map);
    
        SetMapBindings();
    }
    
    public delegate void MapClickHandler(Geopoint center);
    
    /// <summary>
    /// A callback method used to when the map is Clicked
    /// </summary>
    public event MapClickHandler MapClicked;
    
    #if WINDOWS_APP
    private void _map_PointerPressedOverride(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
    {
            Location l;
            _map.TryPixelToLocation(e.GetCurrentPoint(_map).Position, out l);
            Geopoint p = new Geopoint(new BasicGeoposition()
            {
                Latitude = l.Latitude,
                Longitude = l.Longitude
            });
            MapClicked(p);
    }
    #elif WINDOWS_PHONE_APP
    private void _map_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
    {
            Geopoint p;
            _map.GetLocationFromOffset(e.GetCurrentPoint(_map).Position, out p);
            MapClicked(p);
    }
    #endif
