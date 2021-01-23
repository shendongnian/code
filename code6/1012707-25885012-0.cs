    public class Customer
    {
    	[Key]
        public string UserId { get; set; }
    	
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
    
    public class ApplicationUser : IdentityUser
    {
        public virtual Customer Customer { get; set; }
    }
