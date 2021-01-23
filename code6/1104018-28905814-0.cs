    internal class LocationDataContract
    {
        [Key]
        public Guid Id { get; set; }
    
        public string Name { get; set; }
    
        public string Description { get; set; }
    
        public DbGeography Coordinates { get; set; }
    
        public LocationDetailsDataContract Details { get; set; }
    }
    
    internal class LocationDetailsDataContract
    {
        [Key, ForeignKey("Location")]
        public Guid Id { get; set; }
    
        public Planet Planet { get; set; }
    
        public System System { get; set; }
    
        public Sector Sector { get; set; }
    
        [Required]
        public LocationDataContract Location { get; set; }
    }
    
    internal class Planet {
    	[Key]
        public Guid Id { get; set; }
        
        public string Name { get; set; }
    
        public bool? IsCapital { get; set; }
    
        public int Population { get; set; }
    }
    
    internal class System {
    	[Key]
        public Guid Id { get; set; }
        
        public string Name { get; set; }
    }
    internal class Sector {
    	[Key]
        public Guid Id { get; set; }
        
        public string Name { get; set; }
    }
   
