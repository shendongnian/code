    public class Context : DbContext
    {
        public DbSet<ProcessedLog> ProcessedLogs { get; set; }
        public DbSet<QueuedLog> QueuedLogs { get; set; }
        public DbSet<LogLocation> LogLocations { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProcessedLog>()
                        .HasRequired(p => p.Location)
                        .WithOptional(l => l.ProcessedLog);
            modelBuilder.Entity<QueuedLog>()
                        .HasRequired(p => p.Location)
                        .WithOptional(l => l.QueuedLog);
        }
    }
