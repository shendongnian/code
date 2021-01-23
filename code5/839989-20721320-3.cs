    public class ApplicationUser : IdentityUser
    {
        public int ContactId { get; set; }
        public int AdditionalInfoId { get; set; }
        [ForeignKey("ContactId")]
        public virtual Contact Contact { get; set; }
		
        [ForeignKey("AdditionalInfoId")]
        public virtual AdditionalInfo AdditionalInfo { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<AdditionalInfo> AdditionalInfo { get; set; }
    }
	
