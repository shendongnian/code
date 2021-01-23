    var overlay = new MapOverlay
    {
        PositionOrigin = new Point(0.5, 0.5);
        GeoCoordinate = MyGeoPosition; 
        Content = new TextBlock{Text = "My car"}; 
        var ml = new MapLayer { overlay }; 
        MyMap.Layers.Add(ml);
    };
