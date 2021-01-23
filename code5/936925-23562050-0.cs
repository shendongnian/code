      this.ChangeTracker.Entries()
            .Where(e => e.Entity is IAuditableTable && e.State == EntityState.Added)
     .ToList()
     .ForEach(entry => {
            IAuditableTable e = (IAuditableTable)entry.Entity;
            e.ModifiedDate = DateTime.Now;
        });
