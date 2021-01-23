    public class WebDBContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CompanyDBContext());
            modelBuilder.Configurations.Add(new ClientDBContext());
            modelBuilder.Configurations.Add(new QuoteDBContext());
            modelBuilder.Configurations.Add(new RoleDBContext());
            modelBuilder.Configurations.Add(new UserDBContext());
            modelBuilder.Configurations.Add(new InvoiceDBContext());
            modelBuilder.Configurations.Add(new JobDBContext());
            modelBuilder.Configurations.Add(new JobStatusDBContext());            
        }
 
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobStatus> JobStatuses { get; set; }
        public DbSet<Quote> Quotes { get; set; }
    }  
