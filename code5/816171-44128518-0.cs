    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    
    public class MyDbContext: DbContext {
    ...
            public int SaveChanges(bool refreshOnConcurrencyException, RefreshMode refreshMode = RefreshMode.ClientWins) {
                try {
                    return SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex) {
                    foreach (DbEntityEntry entry in ex.Entries) {
                        if (refreshMode == RefreshMode.ClientWins)
                            entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                        else
                            entry.Reload();
                    }
                    return SaveChanges();
                }
            }
    }
