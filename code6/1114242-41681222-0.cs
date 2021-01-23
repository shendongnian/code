        protected TEntity GetByUserID<TEntity>(Guid userId) where TEntity : class
        {
            var user = this.Set<TEntity>()
                .ToList()
                .Cast<IDeletableEntity>()
                .Where(u => (!u.IsDeleted))
                .Cast<TEntity>()
                .Where(u => (u.UserID == userId))
                .FirstOrDefault();
            return user;
        }
