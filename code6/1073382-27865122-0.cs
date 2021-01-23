    public interface IMyDbContext : IDisposable
    {
        IDbSet<Foo> Foos { get; set; }
        IDbSet<Bar> Bars { get; set; }
        int SaveChanges();
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
    }
