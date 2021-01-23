    public override int SaveChanges()
        {
            var Changed = ChangeTracker.Entries();
            if (Changed != null)
            {
                foreach (var entry in Changed.Where(e => e.State == EntityState.Deleted))
                {
                    entry.State = EntityState.Unchanged;
                    if (entry.Entity is ISoftDeletable)
                    {
                        // Set IsDeleted....
                    }
                }
            }
    
            return base.SaveChanges();
        }
