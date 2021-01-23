    var changeSet = ChangeTracker.Entries<IDoNotSave>();
            if (changeSet != null)
            {
                foreach (var entry in changeSet.Where(c => c.State != EntityState.Unchanged))
                {
                    entry.State = EntityState.Unchanged;
                }
            }
