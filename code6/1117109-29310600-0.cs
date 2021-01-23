    [Table("Company")]
    class Company
    {
        [Key]
        public int CompanyID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Location> Locations { get; set; }
    }
    
    [Table("Location")]
    class Location
    {
        [Key]
        public int LocationID { get; set; }
        public string Name { get; set; }
    
        [ForeignKey("Company")]
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }
    }
    
