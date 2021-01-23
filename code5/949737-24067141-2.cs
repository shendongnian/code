    class ServerService : IClientService
    {
    	public void CreateSession( string windowsUserName )
    	{
    		//Do stuff to set up your session as desired
    	}
    
    	public void LongOp( )
    	{
    		//Do something that takes a long time
    		LongRunningFunctionCall();
    		Callback.LongOpResponse();
    	}
    
    	public void Terminate( )
    	{
    		//Do stuff to tear down your session
    	}
    
    	public IClientCallback Callback { get { return OperationContext.Current.GetCallbackChannel<IClientCallback>( ); } }
    }
