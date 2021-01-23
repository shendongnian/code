    ReverseGeocodeQuery query = new ReverseGeocodeQuery();
    query.GeoCoordinate = new GeoCoordinate(geoposition.Coordinate.Latitude, geoposition.Coordinate.Longitude);
    query.QueryCompleted += (s, ev) =>
    {
       if (ev.Error == null && ev.Result.Count > 0)
       {
           List<MapLocation> locations = ev.Result as List<MapLocation>;
           // do what you want with the locations...
       }
    }
    query.QueryAsync();
