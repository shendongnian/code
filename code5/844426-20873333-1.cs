    private async Task<Tuple<Geocoordinate, MapLocation>> GetCurrentCoordinateAsync()
    {
        try
        {
            var geolocator = new Geolocator
                {
                    DesiredAccuracy = PositionAccuracy.High
                };
            var currentPosition = await geolocator.GetGeopositionAsync(
                TimeSpan.FromMinutes(1), 
                TimeSpan.FromSeconds(10))
                .ConfigureAwait(continueOnCapturedContext: false);
            var currentCoordinate = currentPosition.Coordinate;
            var mapLocation = await this.ReverseGeocodeQueryAsync(
                new GeoCoordinate(
                    currentCoordinate.Latitude, 
                    currentCoordinate.Longitude));
			return Tuple.Create(
                currentCoordinate,
                mapLocation.FirstOrDefault());
        }
        catch (Exception)
        {
            // Do something...
            return Tuple.Create(null, null);
        }
    }
