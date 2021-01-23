    public override void SaveChanges()
    {
        foreach (var entry in this.ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.DateCreated = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.DateLastModified = DateTime.Now;
                    break;
            }
        }
        base.SaveChanges();
    }
