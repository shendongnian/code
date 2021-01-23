    private void DetachRemovedRecords()
    {
    	//Get object context to be able to detach entities
    	System.Data.Objects.ObjectContext myObjectContext =
    		((IObjectContextAdapter)myContext).ObjectContext;
    
    	IEnumerable<ObjectStateEntry> deletedRecords =
    		taxesObjectContext.ObjectStateManager.GetObjectStateEntries(
    		System.Data.EntityState.Deleted);
    
    	if (deletedRecords != null
    		&& deletedRecords.Count() > 0)
    	{
    		foreach (ObjectStateEntry stateEntry in deletedRecords)
    		{
    			if (stateEntry != null
    				&& stateEntry.Entity != null)
    			{
    				myObjectContext.Entry(stateEntry.Entity).State =
                           System.Data.EntityState.Detached;
    			}
    		}
    	}
    }
	
	
