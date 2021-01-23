    public partial class MyEFDataModelContainer : IdentityDbContext<User>
    {
        public MyEFDataModelContainer ()
            : base("name=MyEFDataModelContainer")
        {
        }
        public DbSet<User> Users { get; set; }
    }
