    public class License : Entity
    {
        [Key, ForeignKey("Customer")]
        public int LicenseId { get; set; } // consider renaming to CustomerId
        // other properties here
        ...
        public virtual Customer Customer { get; set; }
    }
    
    public class Customer : Entity
    {
        [Key, ForeignKey( "License" )]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set;}
        // other properties here
        ...
        public virtual License License { get; set; }
    }
