    public interface IEntityMappingConfiguration<T> where T : class
    {
        void Map(EntityTypeBuilder<T> builder);
    }
    public static class EntityMappingExtensions
    {
         public static ModelBuilder RegisterEntityMapping<TEntity, TMapping>(this ModelBuilder builder) 
            where TMapping : IEntityMappingConfiguration<TEntity> 
            where TEntity : class
        {
            var mapper = (IEntityMappingConfiguration<TEntity>)Activator.CreateInstance(typeof (TMapping));
            mapper.Map(builder.Entity<TEntity>());
            return builder;
        }
    }
