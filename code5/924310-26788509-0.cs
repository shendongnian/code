    public partial class OriginalContext : DbContext
    {
        ...
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ...
            // This would be overwritten if we left it in the OriginalContext class
            // modelBuilder.Entity<ConvertCarb>().Property(x => x.G_KWH).HasPrecision(18, 4);
        }
    }
    public class ExtendedContext : OriginalContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Put the code here instead so it isn't overwritten when we reverse engineer
            modelBuilder.Entity<ConvertCarb>().Property(x => x.G_KWH).HasPrecision(18, 4);
        }
    }
