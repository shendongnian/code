    public class DomainModelContext : IdentityDbContext<DomainUser>
    {
        public DomainModelContext()
            : base() {}
        public DomainModelContext(string nameOrConnectionString)
            : base(nameOrConnectionString) {}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
