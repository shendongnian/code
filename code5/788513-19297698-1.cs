    public class ParentContext : DbContext
    {
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Child> Childs { get; set; }
    }
