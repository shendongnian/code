    public class Position
    {
        /// <summary>
        /// ...
        /// 
        /// A value within a range -180 and 180
        /// </summary>
        public double Longitude { get; private set; }
        /// <summary>
        /// ...
        /// 
        /// A value within a range -90 and 180
        /// </summary>
        public double Latitude { get; private set; }
        public Position(double longitude, double latitude)
        {
            if (longitude < -180 || longitude > 180)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (latitude < -90 || latitude > 90)
            {
                throw new ArgumentOutOfRangeException();
            }
            Longitude = longitude;
            Latitude = latitude;
        }
    }
