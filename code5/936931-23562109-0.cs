    var auditableTables = this.ChangeTracker.Entries()
                                            .OfType<IAuditableTable>()
                                            .Where(e => e.State == EntityState.Added);
    
    foreach (var table in auditableTables)
    {
        table.ModifiedDate = DateTime.Now;
    }
