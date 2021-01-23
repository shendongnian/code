        public static void ReloadNavigationProperty<TEntity, TElement>(
            this DbContext context, 
            TEntity entity, 
            Expression<Func<TEntity, ICollection<TElement>>> navigationProperty)
            where TEntity : class
            where TElement : class
        {
            context.Entry(entity).Collection<TElement>(navigationProperty).Query();
        }
