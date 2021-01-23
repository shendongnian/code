    public class Context : DbContext
    {
        public Context() : base("name=CS") { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<LanguageType> LanguageTypes { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
			//I'm generating the database using those entities you defined;
			//Here we're demanding not add 's' to the end of table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
