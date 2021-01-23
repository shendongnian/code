    foreach (string propertyName in entry.OriginalValues.PropertyNames)
    {
        var original = entry.OriginalValues.GetValue<object>(propertyName);
        var current = entry.CurrentValues.GetValue<object>(propertyName);
        if (FKList != null)
        {
            GetPossibleForeignKeyValues(tableName, propertyName, ref original, ref current,
                FKList, contextAdapter);
        }
        if ((original == null && current != null) ||
            (original != null && !original.Equals(current)))
        {
            result.Add(new AuditLog()
            {
                UserID = UserId,
                EventDateUTC = changeTime,
                EventType = "M",    // Modified
                TableName = tableName,
                RecordID = primaryKey.ToString(),
                ColumnName = propertyName,
                OriginalValue = original != null ? original.ToString() : "NULL",
                NewValue = current != null ? current.ToString() : "NULL"
            });
        }
    }
