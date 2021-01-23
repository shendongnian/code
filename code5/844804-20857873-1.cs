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
    			// Exception handling exceptionally used for normal code flow
    			// Swallow the exception here
    		}
    		else
    		{
    			throw;
    		}
    	}
    }
