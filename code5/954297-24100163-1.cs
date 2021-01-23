    public class ApplicationUser : IdentityUser
    {
        public bool? IsCurrent { get; set; }
        public virtual Contact Contact { get; set; } 
    }
    public class Contact
    {
        .
        .
        .
        public virtual ApplicationUser User { get; set; } 
    }
    modelBuilder.Entity<Contact>().HasRequired(c => c.User).WithOptional(u => u.Contact);
