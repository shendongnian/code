    IEnumerable<string> pairKeys = allTablesRecords.Select(pair => pair.TableName + "¿" + pair.RecordID);
    return databaseContext.AuditLog.OrderBy(x => x.EventDateUtc)
        .Where(x => pairKeys.Contains(x.TableName + "¿" + x.RecordID))
        .Select(auditLog => new AuditLog
        {
            AuditLogId = auditLog.AuditLogId,
        }).ToList();
