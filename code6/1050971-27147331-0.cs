    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        public virtual ICollection<SupportEvent> SupportEvents { get; set; }
    }
    public class SupportEvent
    {
        [key]
        public Guid Id { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
    // DbContext
    public DbSet<Employee> Employees { get; set; }
    public DbSet<SupportEvent> SupportEvents { get; set; }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
         modelBuilder.Entity<Employee>()
              .HasMany(x => x.SupportEvents)
              .WithMany(x => x.Employees)
              .Map(m => 
               {
                   m.ToTable("EmployeeSupportEvents");
                   m.MapLeftKey("EmployeeId");
                   m.MapRightKey("SupportEventId");
               }
    }
