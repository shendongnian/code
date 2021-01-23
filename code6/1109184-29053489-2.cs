    public static class MapsClass{
    //computes a point on the perimeter given an arbitrary point and distance
    public static GeoCoordinate getDistanceBearing(this GeoCoordinate point, double distance, double bearing = 180)
    {
        double radius = Convert.ToDouble(this.Set.container.Values["Radius"]);
        const double degreestoRadian = Math.PI / 180;
        const double radiantoDegrees = 180 / Math.PI;
        const double earthRadius = 6378137.0;
        var latA = point.Latitude * degreestoRadian;
        var longA = point.Longitude * degreestoRadian;
        var angularDistance = distance / earthRadius;
        var trueCourse = bearing * degreestoRadian;
        var lat = Math.Asin(Math.Sin(latA) * Math.Cos(angularDistance) + Math.Cos(latA) * Math.Sin(angularDistance) * Math.Cos(trueCourse));
        var dlon = Math.Atan2(Math.Sin(trueCourse) * Math.Sin(angularDistance) * Math.Cos(latA),
            Math.Cos(angularDistance) - Math.Sin(latA) * Math.Sin(lat));
        var lon = ((longA + dlon + Math.PI) % (Math.PI * 2)) - Math.PI;
        var result = new GeoCoordinate(lat * radiantoDegrees, lon * radiantoDegrees);
        return result;
    }
    //adds up a series of those points to create a circle
    public static IList<GeoCoordinate> GetCirclePoints(this GeoCoordinate center,
                               double radius, int nrOfPoints = 50)
    {
        var angle = 360.0 / nrOfPoints;
        var locations = new List<GeoCoordinate>();
        for (var i = 0; i <= nrOfPoints; i++)
        {
            locations.Add(center.getDistanceBearing(radius, angle * i));
        }
        return locations;
    }
