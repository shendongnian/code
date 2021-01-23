        public static TEntity Find<TEntity>(this DbSet<TEntity> set, params object[] keyValues) where TEntity : class
        {
            var context = set.GetService<DbContext>();
            var entityType = context.Model.FindEntityType(typeof(TEntity));
            var key = entityType.FindPrimaryKey();
            var entries = context.ChangeTracker.Entries<TEntity>();
            var i = 0;
            foreach (var property in key.Properties)
            {
                var i1 = i;
                entries = entries.Where(e => e.Property(property.Name).CurrentValue == keyValues[i1]);
                i++;
            }
            var entry = entries.FirstOrDefault();
            if (entry != null)
            {
                // Return the local object if it exists.
                return entry.Entity;
            }
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var query = set.AsQueryable();
            i = 0;
            foreach (var property in key.Properties)
            {
                var i1 = i;
                query = query.Where((Expression<Func<TEntity, bool>>)
                 Expression.Lambda(
                     Expression.Equal(
                         Expression.Property(parameter, property.Name),
                         Expression.Constant(keyValues[i1])),
                     parameter));
                i++;
            }
            // Look in the database
            return query.FirstOrDefault();
        }
