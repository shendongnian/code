    public override int SaveChanges()
    {
        var oc = ((IObjectContextAdapter)this).ObjectContext;
        oc.DetectChanges();
        foreach (var ent in oc.ObjectStateManager
                              .GetObjectStateEntries(EntityState.Added)
                              .Select(e => e.Entity)
                              .OfType<QuestionType>())
        {
            oc.ObjectStateManager.ChangeObjectState(ent, EntityState.Unchanged);
        }
        return base.SaveChanges();
    }
