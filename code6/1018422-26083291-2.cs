    public virtual void Delete(T entity) {
        DbEntityEntry dbEntityEntry = this.DbContext.Entry<T>(entity);
        if (dbEntityEntry.State != EntityState.Detached) {
            dbEntityEntry.State = EntityState.Deleted;
        }
        else {
            DbSet dbSet = this.DbContext.Set<T>();
            dbSet.Attach(entity);
            dbSet.Remove(entity);
        }
    }
