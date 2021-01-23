    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.State == EntityState.Added)
            {
                var needToLogAdd = entry.Entity as INeedToLogAdd;
                if (needToLogAdd != null)
                        DoLogAdd(needToLogAdd);
            }
        }
        base.SaveChanges();
    }
