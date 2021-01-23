     [ServiceContract]
     public interface IMSMQService
     {
       [OperationContract(IsOneWay = true)]
       [TransactionFlow(TransactionFlowOption.Allowed)]
       void ShowMessage(string msg);
     } 
