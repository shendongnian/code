        // Nearby location to use as a query hint.
    BasicGeoposition queryHint = new BasicGeoposition();
        // DALLAS
    queryHint.Latitude = 32.7758;
    queryHint.Longitude = -96.7967;
    Geopoint hintPoint = new Geopoint(queryHint);
    MapLocationFinderResult result = await MapLocationFinder.FindLocationsAsync(
                            "street, city, state zip",
                            hintPoint,
                            3);
    if (result.Status == MapLocationFinderStatus.Success)
    {
        if (result.Locations != null && result.Locations.Count > 0)
        {
            Uri uri = new Uri("ms-drive-to:?destination.latitude=" + result.Locations[0].Point.Position.Latitude.ToString() +
                "&destination.longitude=" + result.Locations[0].Point.Position.Longitude.ToString() + "&destination.name=" + "myhome");
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }
    }
