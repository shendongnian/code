    public EditTree()
    {
    	// Get current logged in user, check if user has permission
    	
    	lock(_treeLock)
    	{
    		// Check if tree can be edited at this moment
    		if(!isTreeEditable())
    		{
    			throw new InvalidOperationException();
    			
    			//Or
    			
    			return Json("ERROR"); // Display an error on the client as you wish.
    		}
    		else
    		{
    			// Set the flag in DB so then no one else can edit
    			
    			// Return the tree data for edition
    		}
    	}
    }
