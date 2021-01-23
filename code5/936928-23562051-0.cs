    foreach (var entry in from x in this.ChangeTracker.Entries()
                          where x.Entity is IAuditableTable &&
                                x.State == EntityState.Added
                          select (IAuditableTable)x.Entity
    {
        entry.ModifiedDate = DateTime.Now;
    }
