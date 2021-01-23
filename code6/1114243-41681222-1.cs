        protected TEntity GetByUserID<TEntity>(Guid userID) where TEntity : class
        {
            var user = this.Set<TEntity>()
                .ToList()
                .Cast<IDeletableEntity>()
                .Where(u => (!u.IsDeleted))
                .Cast<IUserID>()
                .Where(u => (u.UserID == userID))
                .FirstOrDefault();
            return user;
        }
