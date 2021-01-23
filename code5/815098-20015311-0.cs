    Geolocator geoLocator = new Geolocator();
    
                Geoposition geoPosition = await geoLocator.GetGeopositionAsync();
                Geocoordinate myGeocoordinate = geoPosition.Coordinate;
    
                GeoCoordinate myGeoCoordinate = CoordinateConverter.ConvertGeoCoOrdinate(myGeocoordinate);
    
                // mapWithMyLocation.Center = myGeoCoordinate;
                mapWithMyLocation.SetView(myGeoCoordinate , 10, MapAnimationKind.Parabolic);
