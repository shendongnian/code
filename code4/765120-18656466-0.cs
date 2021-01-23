    private async void update_position() 
    {
        Geoposition myGeoposition = await myGeolocator.GetGeopositionAsync();
        Geocoordinate myGeocoordinate = myGeoposition.Coordinate;
        myPosition = CoordinateConverter.ConvertGeocoordinate(myGeocoordinate);
        Dispatcher.BeginInvoke(() =>
        {
                this.myMap.Center = myPosition;
                this.myMap.ZoomLevel = 16;
        }
        //update_route();
    }
