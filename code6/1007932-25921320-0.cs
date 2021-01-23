    //Get collection of each insert, update, or delete made on the entity. 
    IEnumerable<DbEntityEntry> changedEntries = this.ChangeTracker.Entries()
        .Where(e => e.State == EntityState.Added
            || e.State == EntityState.Modified
            || e.State == EntityState.Deleted);
    foreach (DbEntityEntry entry in changedEntries)
    {
        EntitySetBase setBase = ObjectContext.ObjectStateManager
            .GetObjectStateEntry(entry.Entity).EntitySet;
        string[] keyNames = setBase.ElementType.KeyMembers.Select(k => k.Name).ToArray();
        string keyName;
        if (keyNames != null)
            keyName = keyNames.FirstOrDefault();
        else
            keyName = "(NotFound)";
    }
