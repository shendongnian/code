    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
            : base("ApplicationContext")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
    }
    public class Entity
    {
        public int Id { get; set; }
    }
    public class User : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Relationship> Relationships { get; set; }
    }
    public class Relationship : Entity
    {
        public virtual ICollection<User> Users { get; set; }
    }
