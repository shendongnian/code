    public virtual void Delete(T entity)
    {
        // An Added entity does not yet exist in the database. If it is then marked as deleted there is
        // nothing to delete because it was not yet inserted, so just make sure it doesn't get inserted.
       dbEntityEntry.State == EntityState.Added
                    ? EntityState.Detached
                    : EntityState.Deleted); 
    }
