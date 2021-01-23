    	public override int SaveChanges()
		{
			using (var scope = new TransactionScope())
			{
				var addedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added).ToList();
				var modifiedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted || e.State == EntityState.Modified).ToList();
				
				foreach (var entry in modifiedEntries)
				{
					ApplyAuditLog(entry);
				}
				int changes = base.SaveChanges();
				foreach (var entry in addedEntries)
				{
					ApplyAuditLog(entry, LogOperation.CreateEntity);
				}
				base.SaveChanges();
				scope.Complete();
				return changes;
			}
		}
		private void ApplyAuditLog(DbEntityEntry entry)
		{
			LogOperation operation;
			switch (entry.State)
			{
				case EntityState.Added:
					operation = LogOperation.CreateEntity;
					break;
				case EntityState.Deleted:
					operation = LogOperation.DeleteEntity;
					break;
				case EntityState.Modified:
					operation = LogOperation.UpdateEntity;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
			ApplyAuditLog(entry, operation);
		}
		private void ApplyAuditLog(DbEntityEntry entry, LogOperation logOperation)
		{
			ILog entity = entry.Entity as ILog;
			if (entity != null)
			{
				AuditLog log = new AuditLog
				{
					Created = DateTime.Now,
					Entity = entry.Entity.GetType().Name,
					EntityId = entity.Id,
					Operation = logOperation,
				};
				AuditLog.Add(log);
			}
		}
