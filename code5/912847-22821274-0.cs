    public void ReverseGeocodeQuery(double longitude, double latitude) {
    MapAddress address;
    ReverseGeocodeQuery reverseQuery = new ReverseGeocodeQuery { 
    GeoCoordinate = currentLocation.coordinate };
    query.QueryCompleted += (s, e) =>
    {
    if (e.Error != null)
        return;
    address = e.Result[0].Information.Address;
    };
    query.QueryAsync();  
    }
    }
