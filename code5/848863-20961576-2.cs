    public class DBContext : DbContext
        {
    
            public DBContext () : base("DatabaseName")
            {
    
            }
    
           
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                
    
            }
    
            public DbSet<YourPocoModelNameHere > YourPocoModelNameHere { get; set; }
           
    
    
            // This is overridden to prevent someone from calling SaveChanges without specifying the user making the change
            public override int SaveChanges()
            {
                throw new InvalidOperationException("User ID must be provided");
            }
            public int SaveChanges(int userId)
            {
                // Get all Added/Deleted/Modified entities (not Unmodified or Detached)
                foreach (var ent in this.ChangeTracker.Entries().Where(p => p.State == System.Data.EntityState.Added || p.State == System.Data.EntityState.Deleted || p.State == System.Data.EntityState.Modified))
                {
                    // For each changed record, get the audit record entries and add them
                    foreach (AuditLog x in GetAuditRecordsForChange(ent, userId))
                    {
                        this.AuditLogs.Add(x);
                    }
                }
    
                // Call the original SaveChanges(), which will save both the changes made and the audit records
                return base.SaveChanges();
            }
    
            private List<AuditLog> GetAuditRecordsForChange(DbEntityEntry dbEntry, int userId)
            {
                List<AuditLog> result = new List<AuditLog>();
    
                DateTime changeTime = DateTime.UtcNow;
    
                // Get the Table() attribute, if one exists
                //TableAttribute tableAttr = dbEntry.Entity.GetType().GetCustomAttributes(typeof(TableAttribute), false).SingleOrDefault() as TableAttribute;
    
                TableAttribute tableAttr = dbEntry.Entity.GetType().GetCustomAttributes(typeof(TableAttribute), true).SingleOrDefault() as TableAttribute;
    
                // Get table name (if it has a Table attribute, use that, otherwise get the pluralized name)
                string tableName = tableAttr != null ? tableAttr.Name : dbEntry.Entity.GetType().Name;
    
                // Get primary key value (If you have more than one key column, this will need to be adjusted)
                var keyNames = dbEntry.Entity.GetType().GetProperties().Where(p => p.GetCustomAttributes(typeof(KeyAttribute), false).Count() > 0).ToList();
    
                string keyName = keyNames[0].Name; //dbEntry.Entity.GetType().GetProperties().Single(p => p.GetCustomAttributes(typeof(KeyAttribute), false).Count() > 0).Name;
    
                if (dbEntry.State == System.Data.EntityState.Added)
                {
                    // For Inserts, just add the whole record
                    // If the entity implements IDescribableEntity, use the description from Describe(), otherwise use ToString()
    
                    foreach (string propertyName in dbEntry.CurrentValues.PropertyNames)
                    {
                        result.Add(new AuditLog()
                        {
                            AuditLogId = Guid.NewGuid(),
                            UserId = userId,
                            EventDateUTC = changeTime,
                            EventType = "A",    // Added
                            TableName = tableName,
                            RecordId = dbEntry.CurrentValues.GetValue<object>(keyName).ToString(),
                            ColumnName = propertyName,
                            NewValue = dbEntry.CurrentValues.GetValue<object>(propertyName) == null ? null : dbEntry.CurrentValues.GetValue<object>(propertyName).ToString()
                        }
                                );
                    }
                }
                else if (dbEntry.State == System.Data.EntityState.Deleted)
                {
                    // Same with deletes, do the whole record, and use either the description from Describe() or ToString()
                    result.Add(new AuditLog()
                    {
                        AuditLogId = Guid.NewGuid(),
                        UserId = userId,
                        EventDateUTC = changeTime,
                        EventType = "D", // Deleted
                        TableName = tableName,
                        RecordId = dbEntry.OriginalValues.GetValue<object>(keyName).ToString(),
                        ColumnName = "*ALL",
                        NewValue = (dbEntry.OriginalValues.ToObject() is IDescribableEntity) ? (dbEntry.OriginalValues.ToObject() as IDescribableEntity).Describe() : dbEntry.OriginalValues.ToObject().ToString()
                    }
                        );
                }
                else if (dbEntry.State == System.Data.EntityState.Modified)
                {
                    foreach (string propertyName in dbEntry.OriginalValues.PropertyNames)
                    {
                        // For updates, we only want to capture the columns that actually changed
                        if (!object.Equals(dbEntry.OriginalValues.GetValue<object>(propertyName), dbEntry.CurrentValues.GetValue<object>(propertyName)))
                        {
                            result.Add(new AuditLog()
                            {
                                AuditLogId = Guid.NewGuid(),
                                UserId = userId,
                                EventDateUTC = changeTime,
                                EventType = "M",    // Modified
                                TableName = tableName,
                                RecordId = dbEntry.OriginalValues.GetValue<object>(keyName).ToString(),
                                ColumnName = propertyName,
                                OriginalValue = dbEntry.OriginalValues.GetValue<object>(propertyName) == null ? null : dbEntry.OriginalValues.GetValue<object>(propertyName).ToString(),
                                NewValue = dbEntry.CurrentValues.GetValue<object>(propertyName) == null ? null : dbEntry.CurrentValues.GetValue<object>(propertyName).ToString()
                            }
                                );
                        }
                    }
                }
                // Otherwise, don't do anything, we don't care about Unchanged or Detached entities
    
                return result;
            }
    
    
        }
