    private AuditLogEntry AuditLogEntryFactory(ObjectStateEntry entry, string entryType) {
            AuditLogEntry auditLogEntry = new AuditLogEntry() {
                EntryDate = DateTime.Now,
                EntryType = entryType,
                Id = Guid.NewGuid(),
                NewValues = AuditLogEntryNewValues(entry),
                Table = entry.EntitySet.Name,
                UserId = _UserId
            };
            if (entryType == _ModifiedEntry) auditLogEntry.OriginalValues = AuditLogEntryOriginalValues(entry);
            return auditLogEntry;
        }
        /// <summary>
        /// Creates a string of all modified properties for an entity.
        /// </summary>
        private string AuditLogEntryOriginalValues(ObjectStateEntry entry) {
            StringBuilder stringBuilder = new StringBuilder();
            entry.GetModifiedProperties().ToList().ForEach(m => {
                stringBuilder.Append(String.Format("{0} = {1},", m, entry.OriginalValues[m]));
            });
            return stringBuilder.ToString();
        }
        /// <summary>
        /// Creates a string of all modified properties' new values for an entity.
        /// </summary>
        private string AuditLogEntryNewValues(ObjectStateEntry entry) {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < entry.CurrentValues.FieldCount; i++) {
                stringBuilder.Append(String.Format("{0} = {1},",
                    entry.CurrentValues.GetName(i), entry.CurrentValues.GetValue(i)));
            }
            return stringBuilder.ToString();
        }
