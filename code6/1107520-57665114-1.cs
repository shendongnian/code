static Geometry Circle(double lat, double lon, double meters)
{
    GeodeticCalculator geoCalc = new GeodeticCalculator(Ellipsoid.WGS84);
    GlobalCoordinates start = new GlobalCoordinates(new Angle(lat), new Angle(lon));
    int sides = 4;
    int degree_unit = 360 / sides;
    var c = new List<NetTopologySuite.Geometries.Coordinate>();
    
    for (int i = 0; i < sides; i++)
    {
        GlobalCoordinates dest = geoCalc.CalculateEndingGlobalCoordinates(start, new Angle(degree_unit * i), meters);
        c.Add(new NetTopologySuite.Geometries.Coordinate(dest.Longitude.Degrees, dest.Latitude.Degrees));
    }
    c.Add(c[0]);
    GeometryFactory gc = new GeometryFactory(new PrecisionModel(), 4326);
    var box = gc.CreatePolygon(c.ToArray());
    var mbc = new MinimumBoundingCircle(box);
    return mbc.GetCircle();
}
