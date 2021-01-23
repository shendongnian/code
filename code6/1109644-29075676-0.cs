    public class PositionsContext:DbContext
    {
        public DbSet<Position> Type { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //define ignores here
            modelBuilder.Entity<Position>().Ignore(t => t.big5);
        }
    }
