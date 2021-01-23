    public override int SaveChanges()
    {
        DateTime tstamp = DateTime.UtcNow;
        var timeStampedEntities = this.ChangeTracker.Entries()
                                      .Where(e => e.State == EntityState.Added
                                               || e.State == EntityState.Modified)
                                      .Select(e => e.Entity).OfType<ITimeStamped>();
        foreach (var timeStamped in timeStampedEntities)
        {
            timeStamped.TimeStamp = tstamp;
        }
        return base.SaveChanges();
    }
