    public class DefaultConnection:DbContext
    {
        public DbSet<CategoriesAdmin> Categories { get; set; }
        public DbSet<Data> Data { get; set; }
    }
