    public class BenchmarkContext : DbContext
    {
        public DbSet<Context> Contexts { get; set; }
        public DbSet<Benchmark> Benchmarks { get; set; }
        public DbSet<MachineType> MachineTypes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Context>()
                .HasRequired(m => m.RemoteBenchmark)
                .WithOptional()
                .Map(m => { m.MapKey("RemoteBenchmarkId"); });
            modelBuilder.Entity<Context>()
                .HasRequired(m => m.DataCenterBenchmark)
                .WithOptional()
                .Map(m => { m.MapKey("DataCenterBenchmarkId"); });
            modelBuilder.Entity<Context>()
                .HasRequired(m => m.IISBenchmark)
                .WithOptional()
                .Map(m => { m.MapKey("IISBenchmarkId"); });
            modelBuilder.Entity<Context>()
                .HasRequired(m => m.LocalBenchmark)
                .WithOptional()
                .Map(m => { m.MapKey("LocalBenchmarkId"); });
        }
    }
