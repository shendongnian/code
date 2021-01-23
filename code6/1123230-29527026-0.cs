    myContext.FullDump();
    public void FullDump(bool ignoreUnchanged = false)
        {
            Debug.WriteLine("=====Begin of Context Dump=======");
            var dbsetList = this.ChangeTracker.Entries();
            foreach (var dbEntityEntry in dbsetList)
            {
                if (ignoreUnchanged && dbEntityEntry.State == EntityState.Unchanged)
                {
                    continue;
                }
                Debug.WriteLine(dbEntityEntry.Entity.GetType().Name + " => " + dbEntityEntry.State);
                switch (dbEntityEntry.State)
                {
                    case System.Data.Entity.EntityState.Detached:
                    case System.Data.Entity.EntityState.Unchanged:
                    case System.Data.Entity.EntityState.Added:
                    case System.Data.Entity.EntityState.Modified:
                        WriteCurrentValues(dbEntityEntry);
                        break;
                    case System.Data.Entity.EntityState.Deleted:
                        WriteOriginalValues(dbEntityEntry);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                Debug.WriteLine("==========End of Entity======");
            }
            Debug.WriteLine("==========End of Context======");
        }
        private static void WriteCurrentValues(DbEntityEntry dbEntityEntry)
        {
            foreach (var cv in dbEntityEntry.CurrentValues.PropertyNames)
            {
                Debug.WriteLine(cv + "=" + dbEntityEntry.CurrentValues[cv]);
            }
        }
        private static void WriteOriginalValues(DbEntityEntry dbEntityEntry)
        {
            foreach (var cv in dbEntityEntry.OriginalValues.PropertyNames)
            {
                Debug.WriteLine(cv + "=" + dbEntityEntry.OriginalValues[cv]);
            }
        }
    }
