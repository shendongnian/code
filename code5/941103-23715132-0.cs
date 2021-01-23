    void OnSavingChanges(object sender, EventArgs e)
        {
            var modifiedEntities = ObjectStateManager.GetObjectStateEntries(EntityState.Modified);
            foreach (var entry in modifiedEntities)
            {
                var modifiedProps = ObjectStateManager.GetObjectStateEntry(entry.EntityKey).GetModifiedProperties();
                var currentValues = ObjectStateManager.GetObjectStateEntry(entry.EntityKey).CurrentValues;
                //iterate and save changes to log for auditing.
            }
        }
