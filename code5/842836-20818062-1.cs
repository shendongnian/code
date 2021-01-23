    [ServiceContract]
    public interface ISoapService
    {
        [OperationContract(Action = ServiceMetadata.Operations.Process,
            ReplyAction = ServiceMetadata.Operations.ProcessResonse)]
        Message Process(Message message);
    
        [OperationContract(Action = ServiceMetadata.Operations.ProcessWithoutResonse)]
        void ProcessWithoutResonse(Message message);
    }
