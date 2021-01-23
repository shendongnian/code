        public virtual void Entry<TEntity>(TEntity entity, Action<DbEntityEntry<TEntity>> action) where TEntity : class
        {
            action(base.Entry(entity));
        }
        [Obsolete("Use overload for unit tests.")]
        public new DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return base.Entry(entity);
            /** or **/
            throw new ApplicationException("Use overload for unit tests.");
        }
