    public override int SaveChanges()
    {
        foreach (DbEntityEntry entry in this.ChangeTracker.Entries())
        {
           Log(entry);
           switch(entry.State)
           {
              case EntityState.Added:
                 Log(GetRelatedEntityKeys(this, entry, EntityState.Added));
                 break;
              case EntityState.Modified:
                 Log(GetRelatedEntityKeys(this, entry, EntityState.Added));
                 Log(GetRelatedEntityKeys(this, entry, EntityState.Deleted));
                 break;
           }
        }
        return base.SaveChanges();
    }
