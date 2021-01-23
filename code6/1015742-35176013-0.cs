    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries<ISoftDeletable>())
        {
            if (entry.State == EntityState.Deleted)
            {
                // Set deleted.
            }
        }
        return base.SaveChanges();
    }
