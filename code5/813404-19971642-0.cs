    private ManualRestEvent signal = new ManualRestEvent(false);//or true based on your req
    
    bool SetHaltProcessing(bool value)
    {
        if(value)
           signal.Reset();
        else
           signal.Set();
    }
    
    while (true)
    {
        signal.WaitOne();
        var messages = receivedQueue.GetMessages(MessageGetLimit);
    
        if (messages.Count() > 0)
        {
            ProcessQueueMessages(messages);
        }
        else
        {
            Task.Delay(PollingInterval);
        }
    }
