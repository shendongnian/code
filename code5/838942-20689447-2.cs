    public class Location : ILocation
        {
           public DbGeography Coordinates { get; set; }
    
           public double? Latitude { get; set; }
    
           public double? Longitude { get; set; }
        }
