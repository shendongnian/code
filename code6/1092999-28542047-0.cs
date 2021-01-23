    private void RemoveFromContext<EntityType>(List<EntityType> entityList)
    			where EntityType : class
    {
    	if (entityList != null && entityList.Count > 0)
    	{
    		foreach (EntityType entity in entityList)
    		{                  
    			myContext.Set<EntityType>().Local.Remove(entity);                    
    		}
    	}
    }
	
