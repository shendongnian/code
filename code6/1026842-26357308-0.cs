    public interface IAuditedEntity {
      string CreatedBy { get; set; }
      DateTime CreatedAt { get; set; }
      string LastModifiedBy { get; set; }
      DateTime LastModifiedAt { get; set; }
    }
    public override int SaveChanges() {
      var addedAuditedEntities = ChangeTracker.Entries<IAuditedEntity>()
        .Where(p => p.State == EntityState.Added)
        .Select(p => p.Entity);
      var modifiedAuditedEntities = ChangeTracker.Entries<IAuditedEntity>()
        .Where(p => p.State == EntityState.Modified)
        .Select(p => p.Entity);
      var now = DateTime.UtcNow;
      foreach (var added in addedAuditedEntities) {
        added.CreatedAt = now;
        added.LastModifiedAt = now;
      }
      foreach (var modified in modifiedAuditedEntities) {
        modified.LastModifiedAt = now;
      }
      return base.SaveChanges();
    }
