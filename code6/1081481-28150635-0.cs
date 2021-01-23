    public partial class MyEFDataModelContainer : IdentityDbContext<ApplicationUser>
    {
        public MyEFDataModelContainer ()
            : base("name=MyEFDataModelContainer")
        {
        }
        public DbSet<User> Users { get; set; }
    }
