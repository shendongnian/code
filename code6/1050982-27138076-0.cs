    [ServiceContract(Namespace = "http://MSMQNoSecurityService")]
    public interface IMSMQService
    {
        [OperationContract(IsOneWay = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void ShowMessage(string msg);
    }
