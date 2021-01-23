    MapAddress address;
    ReverseGeocodeQuery query = new ReverseGeocodeQuery();
    query.GeoCoordinate = myGeoCoordinate;
    query.QueryCompleted += (s, e) =>
       {
            if (e.Error != null)
                return;
    
            address = e.Result[0].Information.Address;
        };
    query.QueryAsync();
