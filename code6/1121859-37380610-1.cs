    public class Markers
        {
            public string Name { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
    
            public double[] LatLong {  get { return   new double[] { Latitude , Longitude}; } }
        }
