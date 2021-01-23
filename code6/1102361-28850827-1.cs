    [Table("AspNetUsers")] 
    public class ApplicationUser
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Username { get; set; }
    }
    public class Employee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public virtual ApplicationUser AppUser { get; set; }
    }
    
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbContext()
            : base("name=DbContext")
        { }
        public IDbSet<ApplicationUser> Users { get; set; }
        public IDbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasRequired(x => x.AppUser)
                .WithMany()
                .Map(m => m.MapKey("UserId")); // Name of you FK column
        }
    }
