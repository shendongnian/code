    /// <summary>
    /// The geo drawing helper.
    /// </summary>
    public class GeoDrawingHelper
    {
        #region Constants
        /// <summary>
        /// The c_ earth radius in kilometers.
        /// </summary>
        public const double c_EarthRadiusInKilometers = 6367.0;
        #endregion
        #region Public Methods and Operators
        /// <summary>
        /// Creates a circle by the initializing point.
        /// </summary>
        /// <param name="center">
        /// The center Point.
        /// </param>
        /// <param name="radius">
        /// The radius in meter.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public static List<Location> CreateCirclePoints(Location center, double radius)
        {
            double lat = ToRadian(center.Latitude); // radians
            double lng = ToRadian(center.Longitude); // radians
            double d = radius / (c_EarthRadiusInKilometers * 1000); // d = angular distance covered on earth's surface
            var locations = new List<Location>();
            for (var x = 0; x <= 360; x++)
            {
                // Calculate the coordinates of the point
                double brng = ToRadian(x);
                double latRadians = Math.Asin((Math.Sin(lat) * Math.Cos(d)) + (Math.Cos(lat) * Math.Sin(d) * Math.Cos(brng)));
                double lngRadians = lng
                                    + Math.Atan2(
                                        Math.Sin(brng) * Math.Sin(d) * Math.Cos(lat), 
                                        Math.Cos(d) - (Math.Sin(lat) * Math.Sin(latRadians)));
                // Add the location
                locations.Add(new Location() { Latitude = ToDegrees(latRadians), Longitude = ToDegrees(lngRadians) });
            }
            return locations;
        }
        /// <summary>
        /// Convert the radian to degrees measure.
        /// </summary>
        /// <param name="radians">
        /// The radians.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public static double ToDegrees(double radians)
        {
            return radians * (180 / Math.PI);
        }
        /// <summary>
        /// Convert the degrees to radian measure.
        /// </summary>
        /// <param name="degrees">
        /// The degrees.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public static double ToRadian(double degrees)
        {
            return degrees * (Math.PI / 180);
        }
        #endregion
    }
