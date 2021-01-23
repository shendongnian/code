    public static async Task<MapLocation> resolveLocationForGeopoint(Geopoint geopoint)
    {
        MapLocationFinderResult result = await MapLocationFinder.FindLocationsAtAsync(geopoint);
        if (result.Status == MapLocationFinderStatus.Success)
        {
            if (result.Locations.Count != 0)
                // Check if the result is really valid
                if (result.Locations[0].Address.Town != "")
                    return result.Locations[0];
        }
        return null;
    }
