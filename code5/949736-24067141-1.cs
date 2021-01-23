    [ServiceContract]
    public interface IClientCallback
    {
    	[OperationContract( IsOneWay = true )]
    	void LongOpResponse( );
    }
