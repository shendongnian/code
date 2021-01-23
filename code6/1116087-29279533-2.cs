    private static void ObjectContext_SavingChanges(object sender, EventArgs e)
    {
        var objCtx = sender as ObjectContext;
        if (objCtx == null)
            return;
        var username = Thread.CurrentPrincipal != null ? Thread.CurrentPrincipal.Identity.Name : String.Empty;
        var auditableEntries =
            (from entry in objCtx.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified)
                where !entry.IsRelationship
                let entity = entry.Entity as IAuditableEntity
                where entity != null
                select new
                {
                    entity,
                    entry.State
                }).ToList();
        foreach (var entry in auditableEntries.Where(x => x.State == EntityState.Added))
        {
            entry.entity.CreatedDateUtc = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
            entry.entity.CreatedBy = username;
        }
        foreach (var entry in auditableEntries.Where(x => x.State == EntityState.Modified))
        {
            entry.entity.ModifiedDateUtc = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
            entry.entity.ModifiedBy = username;
        }
    }
