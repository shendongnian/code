        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<ISoftDeletable>()
                .Where(x => x.State == EntityState.Deleted)
            {
                // Set deleted.
            }
            return base.SaveChanges();
        }
