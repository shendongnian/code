    MapOverlay overlay = new MapOverlay
    {
        GeoCoordinate = myMap.Center,
        Content = new Ellipse
        {
            Fill = new SolidColorBrush(Colors.Red),
            Width = 40,
            Height = 40
         }
    };
    MapLayer layer = new MapLayer();
    layer.Add(overlay);
 
    myMap.Layers.Add(layer);
