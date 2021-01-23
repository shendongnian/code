    // MapTools
    public Map Map
    {
        get { return (Map)GetValue(MapProperty); }
        set { SetValue(MapProperty, value); }
    }
    public static readonly DependencyProperty MapProperty =
        DependencyProperty.Register(
        "Map", 
        typeof(Map), 
        typeof(MapTools), 
        new PropertyMetadata(null));
    
    private void OnButtonClicked(object sender, RoutedEventArgs routedEventArgs)
    {
        // Manipulate map
    }
