    [ServiceContract( CallbackContract = typeof( IClientCallback ), SessionMode = SessionMode.Required )]
    public interface IClientService
    {
    	[OperationContract( IsInitiating = true )]
    	void CreateSession( string windowsUserName );
    	[OperationContract( IsOneWay = true )]
    	void LongOp( );
    	[OperationContract( IsTerminating = true )]
    	void Terminate( );
    }
