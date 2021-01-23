    // Convert Degress to Radians
    //
    private static double Deg2Rad( double deg ) 
    {
       return deg * Math.PI / 180;
    }
    
    // Get Distance between two lat/lng points using the PythagorsTheorm (a*a = (b*b + c*c))
    // on an equirectangular projection
    //
    private double PythagorasEquirectangular( Geoposition coord1, Geoposition coord2 )
    {
    	double lat1 = Deg2Rad( coord1.Coordinate.Latitude );
    	double lat2 = Deg2Rad( coord2.Coordinate.Latitude );
    	double lon1 = Deg2Rad( coord1.Coordinate.Longitude );
    	double lon2 = Deg2Rad( coord2.Coordinate.Longitude );
    
    	double R = 6371; // km
    	double x = (lon2-lon1) * Math.Cos((lat1+lat2)/2);
    	double y = (lat2-lat1);
    	double d= Math.Sqrt(x*x + y*y) * R;
    	return d;
    }
    
    // Find the closest point to your position
    //
    private Geoposition NearestPoint( List<Geoposition> points, Geoposition position  )
    {
    	double min_dist = 999999;
    	Geoposition closest = null;
    	
    	// Calculate distance of each point in the list from your position
    	foreach ( Geoposition point in points )
    	{
    		double dist = PythagorasEquirectangular( position, point );
    		
    		// keep track of which point is the current closest.
    		if ( dist < min_dist )
    		{
    			min_dist = dist;
    			closest = point;
    		}
    	}
    	
    	// return the closest point
    	return closest;
    }
