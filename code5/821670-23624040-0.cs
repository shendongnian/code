    public partial class DbEntities
    {
        public enum AuditActions
        {
            I,
            U,
            D
        }
        public override int SaveChanges()
        {
                ChangeTracker.DetectChanges(); // Important!
                ObjectContext ctx = ((IObjectContextAdapter)this).ObjectContext;
                IEnumerable<ObjectStateEntry> changes = ctx.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Deleted | EntityState.Modified);
                foreach (ObjectStateEntry stateEntryEntity in changes)
                {
                    if (stateEntryEntity.EntitySet.Name != "MobileLoginDatas" && stateEntryEntity.EntitySet.Name != "SystemLookUps")//eliminate these tables
                    {
                        if (SessionData.userId != null && SessionData.userId != 0) //execute only after user login
                        {
                            if (!stateEntryEntity.IsRelationship &&
                                    stateEntryEntity.Entity != null &&
                                        !(stateEntryEntity.Entity is DBAudit))
                            {
                                DBAudit audit = new DBAudit();
                                audit.RevisionStamp = DateTime.Now;
                                audit.UserId = SessionData.userId;
                                audit.TableName = stateEntryEntity.EntitySet.Name;
                                audit.IPAddress = SessionData.clientIpAddress;
                                if (stateEntryEntity.State == EntityState.Added)
                                {//entry is Added 
                                    audit.Data = DictionaryToJsonConverter(GetEntryValueString(stateEntryEntity, false));
                                    audit.Action = AuditActions.I.ToString();
                                }
                                else if (stateEntryEntity.State == EntityState.Deleted)
                                {//entry in deleted
                                    audit.Data = DictionaryToJsonConverter(GetEntryValueString(stateEntryEntity, true));
                                    audit.Action = AuditActions.D.ToString();
                                }
                                else
                                {//entry is modified
                                    audit.Data = DictionaryToJsonConverter(GetEntryValueString(stateEntryEntity, false));
                                    audit.Action = AuditActions.U.ToString();
                                }
                                this.Entry(audit).State = System.Data.EntityState.Added;
                            }
                        }
                    }
                }
          //  }
            return base.SaveChanges();
        }
		///convert the data to json
        string DictionaryToJsonConverter(Dictionary<String, Object> dict)
        {
            var entries = dict.Select(d =>
                string.Format("'{0}': {1}", d.Key, string.Join(",", d.Value)));
            return "{" + string.Join(",", entries) + "}";
        }
        private Dictionary<string, object> GetEntryValueString(ObjectStateEntry entry, Boolean isOriginal)
        {
            var keyValues = new Dictionary<string, object>();
            var values = (IDataRecord) null;
            if (isOriginal)
            {
                values = entry.OriginalValues;
            }
            else
            {
                values = entry.CurrentValues;
            }
            for (int i = 0; i < values.FieldCount; i++)
            {
                keyValues.Add(values.GetName(i), values.GetValue(i));
            }
            return keyValues;
        }
    }
