	public override int SaveChanges()
	{
		var contextAdapter = ((IObjectContextAdapter)this);
		contextAdapter.ObjectContext.DetectChanges();
		var pendingEntities = contextAdapter.ObjectContext.ObjectStateManager
			.GetObjectStateEntries(EntityState.Added | EntityState.Modified)
			.Where(en => !en.IsRelationship).ToList();
		foreach (var entry in pendingEntities) //Encrypt all pending changes
			EncryptEntity(entry.Entity);
		int result = base.SaveChanges();
		foreach (var entry in pendingEntities) //Decrypt updated entities for continued use
			DecryptEntity(entry.Entity);
		return result;
	}
