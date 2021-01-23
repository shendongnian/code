    private Task<double> FindRoute(GeoCoordinate[] wp)
    {
        RouteQuery query = new RouteQuery()
        {
            TravelMode = TravelMode.Driving,
            Waypoints = wp
        };
        var tcs = new TaskCompletionSource<double>();
        query.QueryCompleted += (s, args) =>
            tcs.TrySetResult(args.Result.LengthInMeters);
        query.QueryAsync();
        return tcs.Task;
    }
