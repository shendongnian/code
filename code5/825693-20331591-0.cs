     public static void ContextDumpTest(DbContext context)
        {
            Debug.WriteLine("=====Begin of Context Dump=======");
            var dbsetList = context.ChangeTracker.Entries();
            foreach (var dbEntityEntry in dbsetList)
            {
                Debug.WriteLine(dbEntityEntry.Entity.GetType().Name + " => " + dbEntityEntry.State);
                switch (dbEntityEntry.State)
                {
                    case EntityState.Detached:
                    case EntityState.Unchanged:
                    case EntityState.Added:
                    case EntityState.Modified:
                        WriteValuesPairs(dbEntityEntry);
                        break;
                    case EntityState.Deleted:
                        WriteOriginalValues(dbEntityEntry);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                Debug.WriteLine("==========End of Entity======");
            }
            Debug.WriteLine("==========End of Context======");
        }
        private static void WriteValuesPairs(DbEntityEntry dbEntityEntry)
        {
            foreach (var cv in dbEntityEntry.OriginalValues.PropertyNames)
            {
                if (dbEntityEntry.OriginalValues[cv] == null && dbEntityEntry.CurrentValues[cv] == null) {
                    Debug.WriteLine(cv + " Unchanged: " + "null"); 
                }
                else 
                if  (dbEntityEntry.OriginalValues[cv] != null && dbEntityEntry.CurrentValues[cv] != null
                      &&  dbEntityEntry.OriginalValues[cv].Equals(dbEntityEntry.CurrentValues[cv]) ) {
                    Debug.WriteLine(cv + " Unchanged: " + dbEntityEntry.OriginalValues[cv]);
                }
                else {
                    Debug.WriteLine(cv + " Original= " + dbEntityEntry.OriginalValues[cv] + "-> New= " + dbEntityEntry.CurrentValues[cv]);    
                }
                
            }
        }
