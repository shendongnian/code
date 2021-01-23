    public class lister<TDbSet, TEntity>
    
        where TDbSet   : DbSet<TEntity>
        were  TEntity  : IPEntity
    
    static DbSet<TEntity> Read(DbContext ctx) { return ctx.Set<TEntity>(); }
