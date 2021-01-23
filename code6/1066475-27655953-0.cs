    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface ITransactionService
    {
        [OperationContract(IsInitiating = true, IsTerminating = false)]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        int Start(int userId);
        [OperationContract(IsInitiating = false, IsTerminating = true)]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        int Finish(int userId);
    }
