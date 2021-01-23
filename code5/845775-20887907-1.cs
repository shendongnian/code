    [SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly", Justification = "IDisposable implemented as intended.")]
    public class OrderingDbContext : DbContext, IDisposable
    {
        private readonly IDatabaseInitializer<OrderingDbContext> _initializer;
        public OrderingDbContext(DbConnection connection) : this(connection, new NullDatabaseInitializer<OrderingDbContext>()) { }
        public OrderingDbContext(DbConnection connection,
            IDatabaseInitializer<OrderingDbContext> initializer)
            : base(connection, false)
        {
            _initializer = initializer;
        }
        public DbSet<Order> Orders { get; set; }
        // ...
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(_initializer);
            modelBuilder.Entity<Order>()
                .HasKey(o => new { o.OrderNumber, o.OrderedOn });
            base.OnModelCreating(modelBuilder);
        }
        #region IDisposable
        private bool _disposed;
        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private new void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
                base.Dispose();
            _disposed = true;
        }
        ~OrderingDbContext()
        {
            Dispose(false);
        }
        #endregion
    }
