    public partial class JobScheduleSmsEntities : DbContext
    {
        public JobScheduleSmsEntities()
            : base("name=JobScheduleSmsEntities")
        {
            Database.SetInitializer<JobScheduleSmsEntities>(new CreateDatabaseIfNotExists<JobScheduleSmsEntities>());
        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<ReachargeDetail> ReachargeDetails { get; set; }
        public virtual DbSet<RoleMaster> RoleMasters { get; set; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Types().Configure(t => t.MapToStoredProcedures());
            //modelBuilder.Entity<RoleMaster>()
            //     .HasMany(e => e.Customers)
            //     .WithRequired(e => e.RoleMaster)
            //     .HasForeignKey(e => e.RoleID)
            //     .WillCascadeOnDelete(false);
        }
        public virtual List<Sp_CustomerDetails02> Sp_CustomerDetails()
        {
            //return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Sp_CustomerDetails02>("Sp_CustomerDetails");
            //  this.Database.SqlQuery<Sp_CustomerDetails02>("Sp_CustomerDetails");
            using (JobScheduleSmsEntities db = new JobScheduleSmsEntities())
            {
               return db.Database.SqlQuery<Sp_CustomerDetails02>("Sp_CustomerDetails").ToList();
               
            }
        }
    }
}
    public partial class Sp_CustomerDetails02
    {
        public long? ID { get; set; }
        public string Name { get; set; }
        public string CustomerID { get; set; }
        public long? CustID { get; set; }
        public long? Customer_ID { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? CountDay { get; set; }
        public int? EndDateCountDay { get; set; }
        public DateTime? RenewDate { get; set; }
        public bool? IsSMS { get; set; }
        public bool? IsActive { get; set; }
        public string Contact { get; set; }
    }
