    public class SalesConnection : IConnection
    {
        private readonly DbContext context;
        public SalesConnection()
        {
            this.context = new SalesDbContext();
        }
        public DbContext Context { get { return this.context; } }
    }
