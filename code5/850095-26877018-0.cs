    foreach (string propertyName in dbEntry.OriginalValues.PropertyNames)
                {
                    // For updates, we only want to capture the columns that actually changed
                    if (!Equals(dbEntry.OriginalValues.GetValue<object>(propertyName), dbEntry.CurrentValues.GetValue<object>(propertyName)))
                    {
                        var newVal = getNewValueAsString(dbEntry, tableName, propertyName);
                        result.Add(new AuditLog
                                    {
                                        UserID = currentUser.ID,
                                        Timestamp = changeTime,
                                        EventType = EventType.Modified,
                                        TableName = tableName,
                                        RecordID = dbEntry.OriginalValues.GetValue<int>(keyName),
                                        ColumnName = propertyName,
                                        OriginalValue = dbEntry.OriginalValues.GetValue<object>(propertyName) == null ? null : dbEntry.OriginalValues.GetValue<object>(propertyName).ToString(),
                                        NewValue = newVal
                                    }
                            );
                    }
                }
