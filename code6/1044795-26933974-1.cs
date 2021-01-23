    container.RegisterPerWebRequest<MyDbContext>(() =>
    {
        var context = new MyDbContext();
        context.SavingChanges += UpdateEntities;
        return context;
    });
    private static void UpdateEntities(MyDbContext db)
    {
        var addedEntities =
            from entry in db.ChangeTracker.Entries()
            where entry.State == EntityState.Added
            select entry.Entity as IEntity;
        db.AuditTrailEntries.AddRange(
            from entity in addedEntities
            select new AuditTrailEntry 
            { 
                EntityId = entity.Id, 
                Type = entity.GetType().Name 
            });
    }
