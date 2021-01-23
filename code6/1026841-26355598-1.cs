	public override int SaveChanges(System.Data.Objects.SaveOptions options)
	{
		var timestamp = DateTime.Now;
		foreach (var InsertedAutoTimestampEntity in ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Added).Select(ose => ose.Entity).OfType<IAutoTimestampEntity>())
		{
			InsertedAutoTimestampEntity.CreationDate = timestamp;
			InsertedAutoTimestampEntity.ModificationDate = timestamp;
		}
		foreach (var UpdatedAutoTimestampEntity in ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Modified).Select(ose => ose.Entity).OfType<IAutoTimestampEntity>())
		{
			UpdatedAutoTimestampEntity.ModificationDate = timestamp;
		}
		return base.SaveChanges(options);
	}
