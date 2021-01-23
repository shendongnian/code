	public static class ContextExtension
	{
		public static void ApplyStateChanges(this DbContext context)
		{
			foreach (var entry in context.ChangeTracker.Entries<IObjectWithState>())
			{
				IObjectWithState stateInfo = entry.Entity;
				entry.State = stateInfo.ObjectState.ConvertState();
			}
		}
		public static EntityState ConvertState(this ObjectState state)
		{
			switch (state)
			{
				case ObjectState.Modified:
					return EntityState.Modified;
				case ObjectState.Added:
					return EntityState.Added;
				case ObjectState.Deleted:
					return EntityState.Deleted;
				default:
					return EntityState.Unchanged;
			}
		}
	}
