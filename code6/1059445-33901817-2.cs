    public void DetachAllEntities()
	{
        var changedEntriesCopy = this.ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added ||
                        e.State == EntityState.Modified ||
                        e.State == EntityState.Deleted)
            .ToList();
        foreach (var entity in changedEntriesCopy)
        {
            this.Entry(entity.Entity).State = EntityState.Detached;
	    }
    }
