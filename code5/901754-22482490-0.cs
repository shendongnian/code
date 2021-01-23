    public class ApplicationUser : IdentityUser
    {
    
    // User name, full name, e-mail etc....
        public virtual ICollection<Company> Companies { get; set; }
    }
