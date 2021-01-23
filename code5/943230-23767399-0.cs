    public int SaveChanges(IPrincipal user)
        {
            foreach (var dbEntityEntry in this.ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity &&
                ((e.State == EntityState.Modified) || (e.State == EntityState.Added))))
            {
                ((BaseEntity) dbEntityEntry.Entity).ModificationBy = user.Identity.Name;
                ((BaseEntity)dbEntityEntry.Entity).ModificationDate = TimeProvider.Current.Now;
            }
            return base.SaveChanges();
        }
