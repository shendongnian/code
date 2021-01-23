    [ToTable("ClientStatics")]
    public class ClientStaticsView{}
    public class DataContext : DbContext
    {
        public DbSet<ClientStaticsView> ClientStatics { get; set; }
    }
