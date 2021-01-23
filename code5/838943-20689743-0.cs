    public class Location : ILocation
        {
           public DbGeography Coordinates { get; set; }
    
           public double? Latitude { get; set; }
    
           public double? Longitude { get; set; }
        }
    public class LocationGetFeedsViewModel : LocationGetFeedsBinderModel {
           // change coordinates to string because maybe that's easier to handle on the view.
           public string Coordinates { get; set; }
           // added to sum to the example
           public IEnumerable<SelectListItem> Zones { get; set; } 
    }
    public class LocationGetFeedsBinderModel {
           [Required]
           public double? Latitude { get; set; }
           [Required]
           public double? Longitude { get; set; }
    }
