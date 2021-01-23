    public static void ReAttach<T>(this DbContext context, T entity) where T : class
	{
		var objContext = ((IObjectContextAdapter) context).ObjectContext;
		var objSet = objContext.CreateObjectSet<T>();
		var entityKey = objContext.CreateEntityKey(objSet.EntitySet.Name, entity);
		Object foundEntity;
		var exists = objContext.TryGetObjectByKey(entityKey, out foundEntity);
		// Detach it here to prevent side-effects
		if (exists)
		{
			objContext.Detach(foundEntity);
		}
		context.Set<T>().Attach(entity);
	}
