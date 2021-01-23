        await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        {
            // If needed, create the location pin.
            if(currentLocationPin == null)
            {
                currentLocationPin = new Image() { Source = new BitmapImage(new Uri(smallIconURI)) };
                MapControl.SetNormalizedAnchorPoint(currentLocationPin, new Point(0.5, 1));
                mapControl.Children.Add(currentLocationPin);
            }
 
            // Update the pin's location.  
           
            var currentGeo = new Geopoint(new BasicGeoposition
            {
                Latitude = args.Position.Coordinate.Point.Position.Latitude,
                Longitude = args.Position.Coordinate.Point.Position.Longitude
            });
            MapControl.SetLocation(currentLocationPin, currentGeo);
            mapControl.LandmarksVisible = false;
            mapControl.TrafficFlowVisible = false;
            mapControl.PedestrianFeaturesVisible = false;
            currentGeopoint = currentGeo;
        });
