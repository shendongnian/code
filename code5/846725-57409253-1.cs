    public override Task OnDisconnected(bool stopCalled)
    {
    	var userName = Context.User.Identity.Name;
    
    	List<string> existingUserConnectionIds;
    	ConnectedUsers.TryGetValue(userName, out existingUserConnectionIds);
    
    	// remove the connection id from the List 
    	existingUserConnectionIds.Remove(Context.ConnectionId);
    
    	// If there are no connection ids in the List, delete the user from the global cache (ConnectedUsers).
    	if(existingUserConnectionIds.Count == 0)
    	{
    		// if there are no connections for the user,
    		// just delete the userName key from the ConnectedUsers concurent dictionary
    		List<string> garbage; // to be collected by the Garbage Collector
    		ConnectedUsers.TryRemove(userName, out garbage);
    	}
    
    	return base.OnDisconnected(stopCalled);
    }
