    public override int SaveChanges()
    {
        int result = base.SaveChanges();
    
        foreach (DbEntityEntry dbEntityEntry in this.ChangeTracker.Entries())
        {
            DecryptSecureString(dbEntityEntry.Entity);
        }
        return result;
    }
