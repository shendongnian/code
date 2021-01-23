    public class Position
    {
        public double Longitude { get; private set; }
        public double Latitude { get; private set; }
        /// <summary>
        /// Protects from invalid positions. Use <see cref="Position.Builder"/>
        /// </summary>
        private Position() { }
        /// <summary>
        /// Builds valid positions
        /// </summary>
        public class Builder
        {
            public double Longitude { get; set; }
            public double Latitude { get; set; }
            public Position Build()
            {
                if (Longitude < -180 || Longitude > 180)
                {
                    throw new ArgumentOutOfRangeException();
                }
                if (Latitude < -90 || Latitude > 90)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return new Position() { Latitude = this.Latitude, Longitude = this.Longitude };
            }
        }
    }
