     public void FullDump()
        {
            Debug.WriteLine("=====Begin of Context Dump=======");
            var dbsetList = this.ChangeTracker.Entries();
            foreach (var dbEntityEntry in dbsetList)
            {
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
