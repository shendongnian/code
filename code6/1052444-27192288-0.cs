	public static IEnumerable<Point> RemovePointsOutsideBorders(IEnumerable<Point> points, IEnumerable<Country> countries)
	{
		// join all the country polygons into one (make a stamp)
		var allCountryPolygon = countries.Select(x => x.Polygon).UnionAll();
		// make a single geometry shape from our evenly spaced extent points (cookie dough)
		var pointsGeo = PointsToGeometry(points);
		// do an intersect (stamp country shape over extent based geometry)
		var cookieOfPoints = pointsGeo.STIntersection(allCountryPolygon);
		// how many points left inside? pick them all back out
		for (int n = 1; n <= cookieOfPoints.STNumPoints(); n++)
		{
			var insidePoint = cookieOfPoints.STPointN(n);
			yield return new Point
			{
				Longitude = insidePoint.STX.Value,
				Latitude = insidePoint.STY.Value
			};
		}
	}
    public static SqlGeometry PointsToGeometry(IEnumerable<Point> points)
    {
    	var bld = new SqlGeometryBuilder();
    	bld.SetSrid(4326);
    	bld.BeginGeometry(OpenGisGeometryType.MultiPoint);
    
    	foreach (var p in points)
    	{
    		bld.BeginGeometry(OpenGisGeometryType.Point);
    		bld.BeginFigure(p.Longitude, p.Latitude);
    		bld.EndFigure();
    		bld.EndGeometry();
    	}
    
    	bld.EndGeometry();
    	return bld.ConstructedGeometry;
    }
    public static class ExtensionMethods
    {
    	/// <summary>
    	/// Joins many geometries into one
    	/// </summary>
    	/// <param name="geometries">geometries to join</param>
    	/// <returns>composite geometry</returns>
    	public static SqlGeometry UnionAll(this IEnumerable<SqlGeometry> geometries)
    	{
    		var compositeGeometry = geometries.First();
    		foreach (var g in geometries.Skip(1))
    		{
    			compositeGeometry = compositeGeometry.STUnion(g);
    		}
    		return compositeGeometry;
    	}
    }
