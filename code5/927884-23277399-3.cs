        public class WcfErrorHandler : IErrorHandler
        {
            public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
            {
                if (error is FaultException)
                {
                    //do nothing as it's already FaultException
                    //you should do a transformation only in the case it's required
                }
                else
                {
                    // Generate fault message manually including the exception as the fault detail
                    MessageFault messageFault = MessageFault.CreateFault(
                        new FaultCode("Sender"),
                        new FaultReason(error.Message),
                        error);
                    fault = Message.CreateMessage(version, messageFault, null);
                }
            }
            public bool HandleError(Exception error)
            {
                return true;
            }
        }
