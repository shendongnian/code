    public void DetachAllEntities()
	{
        var changedEntriesCopy = this.ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added ||
                        e.State == EntityState.Modified ||
                        e.State == EntityState.Deleted)
            .ToList();
        foreach (var entry in changedEntriesCopy)
            entry.State = EntityState.Detached;
    }
