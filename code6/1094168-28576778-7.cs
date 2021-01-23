    public class CustomContextManager
    {
    	private MyDbContext context;
    	
    	public CustomContextManager(MyDbContext contextParam)
    	{
    		if (contextParam == null)
    			throw new ArgumentNUllException(nameof(contextParam));
    		
    		this.context = contextParam;
    	}
    	
    	public void PerformBeforeUpdate
    	{
    		//Get object context to be able to perform operations
    		System.Data.Objects.ObjectContext myObjectContext =
    			((IObjectContextAdapter)context).ObjectContext;
    
    		IEnumerable<ObjectStateEntry> updatedRecords =
    			taxesObjectContext.ObjectStateManager.GetObjectStateEntries(
    			System.Data.EntityState.Modified);
    
    		if (updatedRecords != null
    			&& updatedRecords.Count() > 0)
    		{
    			foreach (ObjectStateEntry stateEntry in updatedRecords)
    			{
    				if (stateEntry != null
    					&& stateEntry.Entity != null)
    				{
    					//Do what operations you want instead of below linnes
    					User modifiedUser = stateEntry.Entity as User;
                        if(modifiedUser != null)
    						modifiedUser.Name = "Altered before update";
    				}
    			}
    		}
    	}
    }
