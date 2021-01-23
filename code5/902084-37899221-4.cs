    public void RejectChanges()
    {
        foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity != null).ToList())
        {
            switch (entry.State)
            {
                case EntityState.Modified:
                case EntityState.Deleted:
                    entry.State = EntityState.Modified; //Revert changes made to deleted entity.
                    entry.State = EntityState.Unchanged;
                    break;
                case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;
            }
        }
    }
    public bool SaveChangesInner()
    {
        try
        {
            SaveChanges();
            return true;
        }
        catch (Exception)
        {
            RejectChanges();
            throw;
        }
    }
