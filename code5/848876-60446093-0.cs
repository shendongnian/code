      public override int SaveChanges()
            {
                var auditEntries = new List<AuditEntry>();
                
                var modifiedEntities = ChangeTracker.Entries()
                    .Where(p => p.State == EntityState.Modified).ToList();
               
                foreach (var change in modifiedEntities)
                {
                    var auditEntry = new AuditEntry(change);
                    var primaryKey = GetPrimaryKeys(change);
                    auditEntry.TableName = change.Entity.GetType().Name;//get table name
                   // var id = change.CurrentValues.GetValue<object>("Id").ToString();//get current id
                    auditEntry.EntityId = primaryKey.ToString();
                    auditEntry.EntityTypeId = primaryKey.ToString();
                    auditEntries.Add(auditEntry);
    
    
                    foreach (var prop in change.OriginalValues.PropertyNames)
                    {
                        if (prop == "Id")
                        {
                            continue;
                        }
    
                        switch (change.State)
                        {
                            case EntityState.Modified:
                                if ((change.State & EntityState.Modified) != 0)
                                {
                                    auditEntry.OldValues[prop] = change.OriginalValues[prop].ToString();
                                    auditEntry.NewValues[prop] = change.CurrentValues[prop].ToString();
                                }
                                break;
                        }
    
                    }
                    foreach (var auditEntry1 in auditEntries.Where(_ => !_.HasTemporaryProperties))
                    {
                        Audits.Add(auditEntry1.ToAudit());
                    }
                }
                return base.SaveChanges();
            }
    
            private object GetPrimaryKeys(DbEntityEntry entry)
            {
                var objectStateEntry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
    
                return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
    
            }
