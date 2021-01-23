    public override int SaveChanges()
        {
        IEnumerable<DbEntityEntry<ICreatedTracked>> timeStampedEntities = ChangeTracker.Entries<ICreatedTracked>();
        if (timeStampedEntities != null)
        {
            foreach (var item in timeStampedEntities.Where(t => t.State == EntityState.Added))
                    item.Entity.Created = DateTime.Now;
           }
        return base.SaveChanges();
    }
