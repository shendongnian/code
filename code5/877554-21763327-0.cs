    public class Location
    {
        private double latitude;
        
        public double Latitude
        {
            get
            {
                latitude += offset;
                return latitude;
            }
            set
            {
                latitude = value;
            }
        }
    }
