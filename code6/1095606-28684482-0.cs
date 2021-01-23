    /*
     * Represents a location on a map.
     */
    public class Location
    {
        public int LocationID { get; set; }
        public String Label { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    
        public virtual ICollection< LocationRecreation > LocRecs { get; set; }
    }
    /*
     * Represents a recreation activity type, such as Hiking or Camping, that 
     * can be applied to any location as a tag (each Location may have 0 or more
     * Recreation tags).
     */
    public class Recreation
    {
        public int RecreationID { get; set; }
        public string Label { get; set; }
    
        public virtual ICollection< LocationRecreation > LocationRecs { get; set; }
    }
