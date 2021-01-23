    public abstract class TrackableEntry : ITrack
    {
          public int Id{get; set;}
          public int CreatedBy{get; set;}
          public DateTime CreatedDate{get; set;}
          public int? ModifiedBy{get; set;} 
          public DateTime? ModifiedBy {get; set;}
    }
