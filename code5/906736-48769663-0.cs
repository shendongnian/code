    public virtual void PrepareSave(EntityState state)
    {
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
