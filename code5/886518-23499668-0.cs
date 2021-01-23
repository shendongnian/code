        [ServiceContract]
        public interface IMyService
       {
         [OperationContract(
            Action = "MySoapAction" ]
          Message ServiceFunction(Message input);
       }
