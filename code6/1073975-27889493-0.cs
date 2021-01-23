    public class Entities : DbContext
    {
        public Entities() : base("Entities") { }
        public DbSet<teste> testes { get; set; }
    }
        
