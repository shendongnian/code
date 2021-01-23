    public void DetachAllEntities()
	{
        foreach (var entity in this.ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted))
        {
            this.Entry(entity.Entity).State = EntityState.Detached;
	    }
    }
