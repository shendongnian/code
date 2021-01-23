    public override async Task<int> SaveChangesAsync()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
    
            foreach (var entry in modifiedEntries)
            {
                // try and convert to an Auditable Entity
                var entity = entry.Entity as BaseEntity;
                // call PrepareSave on the entity, telling it the state it is in
                entity?.PrepareSave(entry.State);
            }
    
            var result = await base.SaveChangesAsync();
            return result;
        }
