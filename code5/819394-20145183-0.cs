    public class Entity
    {
        public int Id { get; set; }
        public Entity Parent { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public bool Active { get; set; }
    }
    public class EntityContext : DbContext
    {
        public EntityContext()
            : base(new SqlCeConnection("Data Source=Database.sdf;Persist Security Info=False;"),
                contextOwnsConnection: true)
        {
            // Using a SQL Compact database as backend
        }
        public DbSet<Entity> Entities { get; set; }
    }
