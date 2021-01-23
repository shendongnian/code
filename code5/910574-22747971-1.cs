    MapLayer layer1;
    public MyClass()
    {
       layer1 = new MapLayer;
    }
    private void AppendPushpin(GeoCoordinate MyGeoPosition, string pushpinName)
    {
       Pushpin pushpin1 = new Pushpin();
       pushpin1.GeoCoordinate = MyGeoPosition;
       pushpin1.Content = pushPinName;
       MapOverlay overlay1 = new MapOverlay();
       overlay1.Content = pushpin1;
       overlay1.GeoCoordinate = MyGeoPosition;
       layer1.Add(overlay1);
    }
