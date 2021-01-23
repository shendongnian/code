    public override int SaveChanges() {
        var changeSet = ChangeTracker.Entries();
        if (changeSet != null) {
            foreach (var entry in changeSet.Where(x => x.State != System.Data.Entity.EntityState.Unchanged)) {
                // Implements interface?
                if (entry.Entity is IDateUpdated) {
                    ((IDateUpdated)entry.Entity).DateUpdated = DateTime.Now;
                }
            }
        }
        return base.SaveChanges();
    }
