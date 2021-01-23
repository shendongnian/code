    public MyService()
    {
    	...
    	public MyEntity Create(some parameters)
    	{
    		// Encapuslates multiple SaveChanges calls in a single transaction
    		// You could use a ITransaction if you don't want to reference System.Transactions directly, but don't think it's really useful
    		using (var transaction = new TransactionScope())
    		{
    			var firstEntity = new MyEntity { some parameters };
    			this.context.MyEntities.Add(firstEntity);
    			
    			// Pushes to DB, this'll create an ID
    			this.context.SaveChanges();
    			
    			// Other commands here
    			...
    			
    			var newEntity = new MyOtherEntity { xxxxx };
    			newEntity.MyProperty = firstEntity.ID;
    			this.context.MyOtherEntities.Add(newEntity);
    			
    			// Pushes to DB **again**
    			this.context.SaveChanges();
    			
    			// Commits the whole thing here
    			transaction.Commit();
    			
    			return firstEntity;
    		}
    	}
    }
