    void SavingChanges(object sender, EventArgs e) {
            Debug.Assert(sender != null, "Sender can't be null");
            Debug.Assert(sender is ObjectContext, "Sender not instance of ObjectContext");
            ObjectContext context = (sender as ObjectContext);
            IEnumerable<ObjectStateEntry> modifiedEntities = context.ObjectStateManager.GetObjectStateEntries(EntityState.Modified);
            IEnumerable<ObjectStateEntry> addedEntities = context.ObjectStateManager.GetObjectStateEntries(EntityState.Added);
            addedEntities.ToList().ForEach(a => {
                //Assign ids to objects that don't have
                if (a.Entity is IIdentity && (a.Entity as IIdentity).Id == Guid.Empty)
                    (a.Entity as IIdentity).Id = Guid.NewGuid();
                this.Set<AuditLogEntry>().Add(AuditLogEntryFactory(a, _AddedEntry));
            });
            modifiedEntities.ToList().ForEach(m => {
                this.Set<AuditLogEntry>().Add(AuditLogEntryFactory(m, _ModifiedEntry));
            });
        }
