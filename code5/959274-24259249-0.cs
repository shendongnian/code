    [ServiceContract(SessionMode=SessionMode.Required)]
    public interface INews_Service
    {
        // Initiating - indicates this must be called prior to non initiating calls
        [OperationContract(IsInitiating=true, IsTerminating=false)]
        TOInews Initnews();
       
        // You can choose whether this terminates the session (e.g. if more calls)
        [OperationContract(IsInitiating=false, IsTerminating=true)]
        TOInews Getnews();
    }
