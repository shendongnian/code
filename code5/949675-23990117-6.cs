    public interface IDbContext
    {
        DbSet<T> Set<T>() where T: class; 
    }
    public class EntitiesNew : DbContext, IDbContext
    {
        public EntitiesNew()
            : base("name=EntitiesNew")
        {
        }}
