    [ServiceContract]    
    [SoapHeaders]
    public interface IService
    {
    	[OperationContract]
    	[WCFExtras.Soap.SoapHeader("AuthHeader", typeof(AuthHeader))]
    	bool DoWork();
    }
