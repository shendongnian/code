        public class Mission
    {
        //DB objects
        public int Id { get; set; }
        public int SourceLocationId {get; set}
        public int DestinationLocationId {get; set}
        
        //Virtual objects
        public virtual Location SourceLocation { get; set; }
        public virtual Location DestinationLocation { get; set; }
    }
    
    public class Location
    {
        //DB objects
        public int Id {get;set;}
        
        //Virtual objects
        public virtual ICollection<Mission> SourceMissions { get; set; }
        public virtual ICollection<Mission> DestinationMissions { get; set; }
    }
