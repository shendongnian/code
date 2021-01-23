    public Task<MapAddress> GetCity()
    {
        TaskCompletionSource<MapAddress> tcs = new TaskCompletionSource<MapAddress>();
        ReverseGeocodeQuery reverseGeocode = new ReverseGeocodeQuery();
        reverseGeocode.GeoCoordinate = new GeoCoordinate(10.79845, 106.65063);
        reverseGeocode.QueryCompleted += (sender, e)=> tcs.SetResult(e.Result[0].Information.Address);
        reverseGeocode.QueryAsync();
        return tcs.Task;
    }
