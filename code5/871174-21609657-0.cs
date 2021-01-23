    public struct Coordinate
    {
        private readonly double _x;
        private readonly double _y;
        /// <summary>
        /// Longitude
        /// </summary>
        public double X
        {
            get { return _x; }
        }
        /// <summary>
        /// Latitude
        /// </summary>
        public double Y
        {
            get { return _y; }
        }
        /// <summary>
        /// Initiates a new coordinate.
        /// </summary>
        /// <param name="x">Longitude [-180, 180]</param>
        /// <param name="y">Latitude [-90, 90]</param>
        public Coordinate(double x, double y)
        {
            if (x < -180 || x > 180)
                throw new ArgumentOutOfRangeException(
                    "x", "Longitude value must be in range of -180 and 180.");
            if (y < -90 || y > 90)
                throw new ArgumentOutOfRangeException(
                    "y", "Latitude value must be in range of -90 and 90.");
            _x = x;
            _y = y;
        }
    }
