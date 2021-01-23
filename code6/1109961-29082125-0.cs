    foreach (var mapping in messageEndpointMappings)
    {
    	mapping.Configure((messageType, address) =>
    	{
    		var conventions = context.Settings.Get<Conventions>();
    		if (!(conventions.IsMessageType(messageType) || conventions.IsEventType(messageType) || conventions.IsCommandType(messageType)))
    		{
    			return;
    		}
    
    		if (conventions.IsEventType(messageType))
    		{
    			router.RegisterEventRoute(messageType, address);
    			return;
    		}
    
    		router.RegisterMessageRoute(messageType, address);
    	});
    }
