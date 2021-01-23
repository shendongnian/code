     public class ApplicationUser : IdentityUser
    {
        // other properties
        public virtual ICollection<Space> Space { get;set;};
    }
    public class Space
    {
        // other properties
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
