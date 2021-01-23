        public partial class YourDbContextModelName : DbContext
    {
        public YourDbContextModelName()
            : base("name=YourDbContextConn_StringName")
        {
            Configuration.ProxyCreationEnabled = false;//this is line to be added
        }
        public virtual DbSet<Employee> Employees{ get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
