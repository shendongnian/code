        /// <summary>
        /// This method creates a rectangular geographic envelope that is expanded by the 
        /// specified geographic amount in the original geographic units.  Envelopes 
        /// are useful in that they are simpler than geographic shapes,
        /// and so are much quicker to do intersection testing with.
        /// </summary>
        /// <param name="center">The center point in X and Y.</param>
        /// <returns>A rectangular Envelope that contains the center point.</returns>
        public static Envelope Extend(Coordinate center, double distance)
        {
            Envelope result = new Envelope(center);
            result.ExpandBy(distance);
            return result;
        }
        /// <summary>
        /// Intersection testing with an envelope works the same as with the slower 
        /// and heavier geometries, but should be considerably faster.
        /// </summary>
        /// <param name="testPoint">The test point.</param>
        /// <param name="box">The Envelope that has the box.</param>
        /// <returns>Boolean, true if the box intersects with (contains, or touches) the 
        /// test point.</returns>
        public static bool ContainsTest(Coordinate testPoint, Envelope box)
        {
            return box.Intersects(testPoint);
        }
        /// <summary>
        /// To get a geographic envelope 10 pixels around an X, Y position of a pixel 
        /// coordinate on the map, in terms of the actual visible map component (and not 
        /// the possibly extended buffer of the map frame).
        /// </summary>
        /// <param name="center">The pixel position of the center on the map control</param>
        /// <param name="map">The map control</param>
        /// <returns>A Geographic envelope</returns>
        public static Envelope Expand(Point center, Map map)
        {
            Rectangle rect = new Rectangle(center.X - 10, center.Y - 10, 20, 20);
            // Get the geographic points
            return map.PixelToProj(rect);
        }
        /// <summary>
        /// To get a pixel coordinate bounding rectangle around a geographic point for 
        /// hit testing is similar.
        /// </summary>
        /// <param name="test">The geographic coordinate</param>
        /// <param name="map">The map control</param>
        /// <returns>A pixel coordinate rectangle for the specified coordinate</returns>
        public static Rectangle Bounds(Coordinate test, Map map)
        {
            Envelope result = new Envelope(center);
            result.ExpandBy(distance);
            return map.ProjToPixel(result);
        }
