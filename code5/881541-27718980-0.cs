    // Function to draw circle on map:
    
    private void DrawCircle(BasicGeoposition CenterPosition, int Radius)
    	{
    	Color FillColor = Colors.Purple;
    	Color StrokeColor = Colors.Red;
    	FillColor.A = 80;
    	StrokeColor.A = 80;
    	Circle = new MapPolygon
    		{
    			StrokeThickness = 2,
    			FillColor = FillColor,
    			StrokeColor = StrokeColor,
    			Path = new Geopath(Functions.CalculateCircle(CenterPosition, Radius))
    		};
    	mpBingMaps.MapElements.Add(Circle);
    }
    
    // Constants and helper functions:
    
    const double earthRadius = 6371000D;
    const double Circumference = 2D * Math.PI * earthRadius;
    
    public static List<BasicGeoposition> CalculateCircle(BasicGeoposition Position, double Radius)
    {
    	List<BasicGeoposition> GeoPositions = new List<BasicGeoposition>();
    	for (int i = 0; i <= 360; i++)
    	{
    		double Bearing = ToRad(i);
    		double CircumferenceLatitudeCorrected = 2D * Math.PI * Math.Cos(ToRad(Position.Latitude)) * earthRadius;
    		double lat1 = Circumference / 360D * Position.Latitude;
    		double lon1 = CircumferenceLatitudeCorrected / 360D * Position.Longitude;
    		double lat2 = lat1 + Math.Sin(Bearing) * Radius;
    		double lon2 = lon1 + Math.Cos(Bearing) * Radius;
    		BasicGeoposition NewBasicPosition = new BasicGeoposition();
    		NewBasicPosition.Latitude = lat2 / (Circumference / 360D);
    		NewBasicPosition.Longitude = lon2 / (CircumferenceLatitudeCorrected / 360D);
    		GeoPositions.Add(NewBasicPosition);
    	}
    	return GeoPositions;
    }
    
    private static double ToRad(double degrees)
    {
    	return degrees * (Math.PI / 180D);
    }
