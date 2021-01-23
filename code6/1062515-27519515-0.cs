     if (changeSet != null)
                {
                    foreach (var entry in changeSet.Where(c => c.State == EntityState.Added))
                    {
                        obj = entry.Entity;
                      
                    }
                    foreach (var entry in changeSet.Where(c => c.State == EntityState.Modified))
                    {
                        obj = entry.Entity;
                      
                    }
                }
