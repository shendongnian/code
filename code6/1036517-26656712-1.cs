    private void SetInsertMetadata(TDomainEntity entity)
    {
    	if(entity == null) return;  //To prevent errors below
    	
    	entity.InsertDT = DateTime.UtcNow;
    
        //Get all properties of the entity that also implement the TDomainEntity interface
    	var props = entity.GetType().GetProperties()
        				.Where(p => typeof(TDomainEntity).IsAssignableFrom(p.PropertyType));
    
        //Recurse through each property:
    	foreach(var p in props)
    	{
    		SetInsertMetadata((TDomainEntity)p.GetValue(entity));
    	}
    }
