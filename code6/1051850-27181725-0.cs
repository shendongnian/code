		// Place the call to Add in a try block in case the user has disabled agents.
		try
		{
			ScheduledActionService.Add( task );
		}
		catch ( InvalidOperationException exception )
		{
			if ( exception.Message.Contains( "BNS Error: The action is disabled" ) )
			{
               // Background agents for this application have been disabled by the user.
			}
			if ( exception.Message.Contains( "BNS Error: The maximum number of ScheduledActions of this type have already been added." ) )
			{
			}
            //...
		}
