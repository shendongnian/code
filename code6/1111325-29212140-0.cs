    static class EfUtils
    {
    	public static void SyncCollections<TEntity>(
    		ICollection<TEntity> collectionFromDb,
    		IEnumerable<TEntity> collectionFromVm,
    		IEqualityComparer<TEntity> equalityComparer,
    		Action<TEntity, TEntity> syncAction)
    		where TEntity : class, new()
    	{
    		var dbToVmEntitiesMap = new Dictionary<TEntity, TEntity>();
    		var newEntities = new List<TEntity>();
    
    		foreach (var vmEntity in collectionFromVm)
    		{
    			var dbEntity = collectionFromDb.FirstOrDefault(x => equalityComparer.Equals(x, vmEntity));
    			if (dbEntity == null)
    			{
    				dbEntity = new TEntity();
    				newEntities.Add(dbEntity);
    			}
    
    			dbToVmEntitiesMap.Add(dbEntity, vmEntity);
    		}
    
    		var removedEntities = collectionFromDb.Where(x => !dbToVmEntitiesMap.ContainsKey(x)).ToList();
    
    		foreach (var addedOrUpdatedEntityPair in dbToVmEntitiesMap)
    		{
    			syncAction(addedOrUpdatedEntityPair.Key, addedOrUpdatedEntityPair.Value);
    		}
    
    		foreach (var removedEntity in removedEntities)
    		{
    			collectionFromDb.Remove(removedEntity);
    		}
    
    		foreach (var newEntity in newEntities)
    		{
    			collectionFromDb.Add(newEntity);
    		}
    	}
    }
