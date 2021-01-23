    geolocator.ReportInterval = ....; // or MovementThreshold
    geolocator.PositionChanged += GeolocatorPositionChanged;
    double YOUR_HORIZONTAL_ACCURACY = 20; // accuracy in metres
    double YOUR_VERTICAL_ACCURACY = 20;   // accuracy in metres
    private void GeolocatorPositionChanged(Geolocator sender, PositionChangedEventArgs args)
    {
        GeoCoordinate coordinate = args.Position.Coordinate.ToGeoCoordinate(); // ToGeoCoordinate method is extension from the Windows Phone Toolkit
        if ((Double.IsNaN(coordinate.HorizontalAccuracy) || coordinate.HorizontalAccuracy > YOUR_HORIZONTAL_ACCURACY) && (Double.IsNaN(coordinate.VerticalAccuracy) || coordinate.VerticalAccuracy > YOUR_VERTICAL_ACCURACY))
        {
            // weak
        }
        else
        {
            // high
        }
