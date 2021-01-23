    public override int SaveChanges()
    {
        ChangeTracker.DetectChanges();
        var entries = ChangeTracker.Entries<IAuditable>();
        if (entries != null)
        {
            foreach (DbEntityEntry<IAuditable> entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.SystemFields = new SystemFields
                        {
                            SysActivityCode = ActivityCode,
                            SysCreationUser = UserId,
                            SysCreationDate = DateTime.UtcNow
                        };
                        break;
                    case EntityState.Modified:
                        entry.Entity.SystemFields.SysModificationDate = DateTime.UtcNow;
                        entry.Entity.SystemFields.SysModificationUser = UserId;
                        entry.Entity.SystemFields.SysActivityCode = ActivityCode;
                        break;
                }
            }
        }
 
        return base.SaveChanges();
    }
