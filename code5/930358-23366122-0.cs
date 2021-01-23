    Geolocator geolocator = new Geolocator
    {
         DesiredAccuracy = PositionAccuracy.High
    };
    
    geolocator.PositionChanged += geolocator_PositionChanged;
    private static void geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
    {
         var speed = args.Position.Coordinate.Speed;
    }
