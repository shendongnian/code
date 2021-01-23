        public static void ReloadEntity<TEntity>(
            this DbContext context, 
            TEntity entity)
            where TEntity : class
        {
            context.Entry(entity).Reload();
        }
