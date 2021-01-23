    public double CalculateDistance(System.Device.Location.GeoCoordinate geo, System.Device.Location.GeoCoordinate geo2)
    {
        //var R = 6371; // result in km
        var R = 6371000; // result in m
        var dLat = (geo2.Latitude - geo.Latitude).ToRad();
        var dLon = (geo2.Longitude - geo.Longitude).ToRad();
        var lat1 = geo.Latitude.ToRad();
        var lat2 = geo2.Latitude.ToRad();
    
        var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        return R * c;
    }
