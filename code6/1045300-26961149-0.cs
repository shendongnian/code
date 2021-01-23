            switch (entry.State)
            {
                case EntityState.Modified:
                    entry.State = EntityState.Unchanged;
                    break;
                case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;                    
                case EntityState.Deleted:
                    entry.State = EntityState.Unchanged;
                    break;
                default: break;
            }
