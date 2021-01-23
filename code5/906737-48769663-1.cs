    public override void PrepareSave(EntityState state)
    {
        var context = new DbContext();
        var maxId = context.Contacts.Max(model => model.ContactId);
        ContactId = maxId + 1;
        context.Dispose();
        var identityName = Thread.CurrentPrincipal.Identity.Name;
        var now = DateTime.UtcNow;
        if (state == EntityState.Added)
        {
            CreateBy = identityName ?? "unknown";
            CreateDate = now;
        }
        LastModifedBy = identityName ?? "unknown";
        LastModifed = now;
    }
