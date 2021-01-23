        async void GetLocation(string address, Geopoint queryHintPoint)
        {
            var result = await MapLocationFinder.FindLocationsAsync(address, queryHintPoint);
            // Get the coordinates
            if(result.Status == MapLocationFinderStatus.Success)
            {
                double lat = result.Locations[0].Point.Position.Latitude;
                double lon = result.Locations[0].Point.Position.Longitude;
            }
        }
