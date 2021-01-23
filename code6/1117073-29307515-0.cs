	return allTablesRecords
		.SelectMany(pair => 
			databaseContext.AuditLog.OrderBy(x => x.EventDateUtc)
				.Where(x => x.TableName == pair.TableName && x.RecordId == pair.RecordID)
				.Select(auditLog => new AuditLog
				{
					AuditLogId = auditLog.AuditLogId,
				})
		);
