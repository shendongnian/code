    internal static class ModelBuilderExtensions
    {
       public static void AddConfiguration<TEntity>(
         this ModelBuilder modelBuilder, 
         DbEntityConfiguration<TEntity> entityConfiguration) where TEntity : class
       {     
           modelBuilder.Entity<TEntity>(entityConfiguration.Configure);
       }
    }
    internal abstract class DbEntityConfiguration<TEntity> where TEntity : class
    {     
        public abstract void Configure(EntityTypeBuilder<TEntity> entity);
    }
