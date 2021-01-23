    public class MyDbContext : DbContext, IDatabaseContext {
    
        public IDbSet<MyEntity1> Entities1 { get; set; }
    
    }
