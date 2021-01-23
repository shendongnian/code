    private static IList<EntityKey> GetRelatedEntityKeys(DbContext context, DbEntityEntry entry, EntityState entityState)
    {
        ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
        ObjectStateManager objectStateManager = objectContext.ObjectStateManager;
        ObjectStateEntry pivotEntityStateEntry;
        if (!objectStateManager.TryGetObjectStateEntry(entry.Entity, out pivotEntityStateEntry))
        {
            return null;
        }
        EntityKey pivotEntityKey = pivotEntityStateEntry.EntityKey;
        if (entityState == EntityState.Deleted)
        {
            return objectStateManager.GetObjectStateEntries(EntityState.Deleted)
                .Where(e => e.IsRelationship && ((EntityKey)e.OriginalValues[0] == pivotEntityKey || (EntityKey)e.OriginalValues[1] == pivotEntityKey))
                .Select(e => (EntityKey)e.OriginalValues[0] == pivotEntityKey ? (EntityKey)e.OriginalValues[1] : (EntityKey)e.OriginalValues[0])
                .ToList();
        }
        else
        {
            return objectStateManager.GetObjectStateEntries(EntityState.Added)
                .Where(e => e.IsRelationship && ((EntityKey)e.CurrentValues[0] == pivotEntityKey || (EntityKey)e.CurrentValues[1] == pivotEntityKey))
                .Select(e => (EntityKey)e.CurrentValues[0] == pivotEntityKey ? (EntityKey)e.CurrentValues[1] : (EntityKey)e.CurrentValues[0])
                .ToList();
        }
    }
