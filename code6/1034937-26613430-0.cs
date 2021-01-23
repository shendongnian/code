    //Internal class recommended
    public class MeasuringContext : DbContext
    {
         public DbSet<Measure> Measures { get; set; }
    }
