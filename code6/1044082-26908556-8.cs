    public interface ITrack
    {
          int Id{get; set;}
          int CreatedBy{get; set;}
          DateTime CreatedDate{get; set;}
          int? ModifiedBy{get; set;} // int? because at first add, there is no modification
          DateTime? ModifiedBy {get; set;}
    }
