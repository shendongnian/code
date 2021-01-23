        [ServiceContract]
        private interface IEchoService
        {
            [OperationContract]
            [WebInvoke]
            Message Echo(Message s);
        }
        private class EchoService : IEchoService
        {
            public Message Echo(Message s)
            {
                return s;
            }
        }
