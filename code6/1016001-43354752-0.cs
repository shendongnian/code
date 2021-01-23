        public override async Task<int> SaveChangesAsync()
        {
            foreach (var history in this.ChangeTracker.Entries()
                .Where(e => e.Entity is IModificationHistory && (e.State == EntityState.Added ||
                    e.State == EntityState.Modified))
                .Select(e => e.Entity as IModificationHistory)
                )
            {
                history.DateModified = DateTime.Now;
                if (history.DateCreated <= DateTime.MinValue)
                {
                    history.DateCreated = DateTime.Now;
                }
            }
            int result = await base.SaveChangesAsync();
            foreach (var history in this.ChangeTracker.Entries()
                                            .Where(e => e.Entity is IModificationHistory)
                                            .Select(e => e.Entity as IModificationHistory))
            {
                history.IsDirty = false;
            }
            return  result;
        }
