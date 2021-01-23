    namespace ServiceLibrary.Server
    {
	    [ServiceContract]
        public interface IMyService
        {
            [OperationContract]
            byte[] Execute(MyRequest request);
        }
    }
    namespace ServicerLibrary.Client
    {
	    [ServiceContract]
        public interface IMyService : Server.IMyService
        {
            [OperationContract]
            Task<byte[]> ExecuteAsync(MyRequest request);
        }
    }
