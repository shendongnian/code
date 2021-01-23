    MessageQueue messageQueue = ...;
    TimeSpan queueReceiveTimeout = ...;
    
    while (true)
    {
    	try
    	{
    		Message message = messageQueue.Receive(queueReceiveTimeout);
    		...
    	}
    	catch (MessageQueueException msmqEx)
    	{ 
    		if (msmqEx.MessageQueueErrorCode == MessageQueueErrorCode.IOTimeout)
    		{
    			// Exception handling exceptionaly used for normal code flow
    			// Smallow the exception here
    		}
    		else
    		{
    			throw;
    		}
    	}
    }
