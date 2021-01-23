    public class SchoolContext : DbContext
    {
    
    public override int SaveChanges()
    {
        var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
        var currentUsername = HttpContext.Current != null && HttpContext.Current.User != null
            ? HttpContext.Current.User.Identity.Name
            : "Anonymous";
        foreach (var entity in entities)
        {
            if (entity.State == EntityState.Added)
            {
                ((BaseEntity)entity.Entity).DateCreated = DateTime.Now;
                ((BaseEntity)entity.Entity).UserCreated = currentUsername;
            }
            ((BaseEntity)entity.Entity).DateModified = DateTime.Now;
            ((BaseEntity)entity.Entity).UserModified = currentUsername;
        }
        return base.SaveChanges();
    }
    }
    public override Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
       
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            var currentUsername = HttpContext.Current != null && HttpContext.Current.User != null
                ? HttpContext.Current.User.Identity.Name : "Anonymous";
            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).DateCreated = DateTime.Now;
                    ((BaseEntity)entity.Entity).UserCreated = currentUsername;
                }
                ((BaseEntity)entity.Entity).DateModified = DateTime.Now;
                ((BaseEntity)entity.Entity).UserModified = currentUsername;
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        }
