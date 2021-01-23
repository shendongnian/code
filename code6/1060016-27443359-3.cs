    void IErrorHandler.ProvideFault(Exception error, MessageVersion version, ref Message fault)
    {
        if (error is FaultException)
        {
            // Let WCF do normal processing
        }
        else
        {
            try
            {
                // This takes an exception, and tries to serialize it, so
                // that it can be encoded into a <soap:Fault> <soap:Detail>
                // element. The client, can then deserialize the detail to
                // rebuild the exception information.
                //
                // Not all exceptions are serializable! Thus if our
                // serialization fails, then we will instead return a
                // general exception whose content will be string
                // representatiion of the exception.
                MessageFault messageFault = MessageFault.CreateFault(
                    new FaultCode("ExceptionMarshallingErrorHandlerV1"),
                    new FaultReason(error.Message),
                    error,
                    new NetDataContractSerializer());
                if (messageFault != null)
                {
                    fault = Message.CreateMessage(version, messageFault, null);
                }
            }
            catch (Exception)
            {
                try
                {
                    // This isn't strictly correct, as the "stack trace" information
                    // is lost, and the InnerExceptions too....but I didn't think them
                    // important at the time...and anyway all the exceptions I expected
                    // were serializable, so this shouldn't have been hit.
                    //
                    // This is effectively a different way to create the MessageFault
                    // compared to yours.
                    //
                    // If you look at the "ppwcode" code, then it tries to
                    // handle the non-serializable exceptions in a better way...by
                    // recording the stack trace and InnerExceptions.
                    //
                    // So I would suggest using:
                    //
                    // Exception ex = HandleNonSerializableException(error);
    
                    Exception ex = new Exception(error.ToString());
    
                    MessageFault messageFault = MessageFault.CreateFault(
                        new FaultCode("ExceptionMarshallingErrorHandlerV1"),
                        new FaultReason(error.Message),
                        ex,
                        new NetDataContractSerializer());
                    if (messageFault != null)
                    {
                        fault = Message.CreateMessage(version, messageFault, null);
                    }
                }
                catch
                {
                    // Pass the "exception" back as a FaultException
    
                    MessageFault messageFault = MessageFault.CreateFault(
                        new FaultCode("Exception (non-serializable)"),
                        new FaultReason(error.Message));
                    if (messageFault != null)
                    {
                        fault = Message.CreateMessage(version, messageFault, null);
                    }
    
                    fault = Message.CreateMessage(version, messageFault, null);
                }
            }
        }
    }
