    [ServiceContract(SessionMode = SessionMode.Allowed)]
       public interface IFromClientToServerMessages
       {
           [OperationContract(IsOneWay = false)]
           void DisplayTextOnServerAsFromThisClient(string message);
       }
