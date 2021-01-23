    public class Customer
    {
        [Key, ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
    public class ApplicationUser : IdentityUser
    {
        public virtual Customer Customer { get; set; }
    }
