    var auditableTables = this.ChangeTracker.Entries()
                                            .Where(e => e.State == EntityState.Added)
                                            .Select(e => e.Entity)
                                            .OfType<IAuditableTable>();
    
    foreach (var table in auditableTables)
    {
        table.ModifiedDate = DateTime.Now;
    }
