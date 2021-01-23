    private async Task<IList<MapLocation>> ReverseGeocodeQueryAsync(GeoCoordinate geoCoordinate)
    {
        var tcs = new TaskCompletionSource<IList<MapLocation>>();
        EventHandler<QueryCompletedEventArgs<IList<MapLocation>>> handler =
            (s, e) =>
            {
                if (e.Cacelled)
                {
                    tcs.TrySetCancelled();
                }
                else if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
        var query = new ReverseGeocodeQuery{ GeoCoordinate = geoCoordinate };
        try
        {
            query.QueryCompleted += handler;
            query.QueryAsync();
            return await tcs.Task;
        }
        finally
        {
            query.QueryCompleted -= handler;
        }
    }
