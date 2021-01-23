    public override Task OnConnected()
    {
    	Trace.TraceInformation("MapHub started. ID: {0}", Context.ConnectionId);
    	
    	var userName = "testUserName1"; // or get it from Context.User.Identity.Name;
    
    	// Try to get a List of existing user connections from the cache
    	List<string> existingUserConnectionIds;
    	ConnectedUsers.TryGetValue(userName, out existingUserConnectionIds);
    
    	// happens on the very first connection from the user
    	if(existingUserConnectionIds == null)
    	{
    		existingUserConnectionIds = new List<string>();
    	}
    
    	// First add to a List of existing user connections (i.e. multiple web browser tabs)
    	existingUserConnectionIds.Add(Context.ConnectionId);
    
    	
    	// Add to the global dictionary of connected users
    	ConnectedUsers.TryAdd(userName, existingUserConnectionIds);
    
    	return base.OnConnected();
    }
