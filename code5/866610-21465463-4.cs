    public class Person
    {   [Key]
        public int Id { get; set; }
        public ICollection<View> Viewers { get; set; }
    }
    public class View
    {   [Key]
        public int Id { get; set; }
        public int ViewerId { get; set; } //this is a ForeingKey
        public Person Viewer { get; set; }
    }
    public class MyDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<View> Views { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<View>().HasRequired(a => a.Viewer).WithMany().HasForeignKey(a => a.ViewerId);
            base.OnModelCreating(modelBuilder);
        }
    }
