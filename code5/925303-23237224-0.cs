        [ServiceContract]
        interface IMyService1_1
        {
           [OperationContract]
           ResponseMsgContract1 Operation1(RequestMsgContract1 arguments);
        }
        [ServiceContract]
        interface IMyService1_2
        {
           [OperationContract]
           ResponceMsgContract2 Operation2();
        }
