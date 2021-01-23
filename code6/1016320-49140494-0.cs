        public interface IDatabaseContext
        {
            DbSet<T> Set<T>() where T : class;
            DbEntityEntry<T> Entry<T>(T entity) where T : class;
            int SaveChanges();
            Task<int> SaveChangesAsync();
            void AddOrUpdateEntity<TEntity>(params TEntity[] entities) where TEntity : class;
    }
