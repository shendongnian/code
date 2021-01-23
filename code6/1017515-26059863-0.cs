    public MyService()
    {
    	...
    	public MyEntity Create(some parameters)
    	{
    		var entity = new MyEntity(some parameters);
    		this.context.MyEntities.Add(entity);
    		
    		// Actually commits the whole thing in a transaction
    		this.context.SaveChanges();
    		
    		return entity;
    	}
    	
    	...
    	
    	// Example of a complex query you want to use multiple times in MyService
    	private IQueryable<MyEntity> GetXXXX_business_name_here(parameters)
    	{
    		return this.context.MyEntities
    			.Where(z => ...)
    			.....
    			;
    	}
    }
