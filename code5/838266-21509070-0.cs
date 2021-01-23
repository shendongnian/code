    public class Package
    {
        public Int32 Id {get; set;}
        public String Name {get; set;}
        public Int32 UserId {get; set;}
        public virtual User Creator {get; set;}    
    }
    public class User
    {
        public User()
        {
            Packages = new Collection<Package>();
         }
        public Int32 Id {get; set;}
        public String Name {get; set;}
        public virtual ICollection<Package> Packages {get; set;}
    }
    public class PackageContext : DbContext
    {
        public DbSet<Package> Packages {get; set;}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Package>().HasRequired(current => current.Creator)
                .WithMany(c=>c.Packages)
                .HasForeignKey(c=>c.UserId)
                .WillCascadeOnDelete(false);
        base.OnModelCreating(modelBuilder);
        }
    }
