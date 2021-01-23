     var geolocator = new Geolocator();
     geolocator.DesiredAccuracyInMeters = 100;
     Geoposition position = await geolocator.GetGeopositionAsync();
 
     // reverse geocoding
     BasicGeoposition myLocation = new BasicGeoposition
         {
             Longitude = position.Coordinate.Longitude,
             Latitude = position.Coordinate.Latitude
         };
     Geopoint pointToReverseGeocode = new Geopoint(myLocation);
     MapLocationFinderResult result = await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);
     // here also it should be checked if there result isn't null and what to do in such a case
     string country = result.Locations[0].Address.Country;
