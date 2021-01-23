public partial class Q4Sandbox : DbContext
    {
        public Q4Sandbox()
            : base("name=Q4Sandbox")
        {
        }
        public virtual DbSet<EmployeeDTO> Employees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {           
           var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
