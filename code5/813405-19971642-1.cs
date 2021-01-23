    private ManualRestEvent signal = new ManualRestEvent(false);//or true based on your req
    //Setting true is to allow processing and false is to halt the processing
    
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
    bool SetHaltProcessing(bool value)
    {
        if(value)
           signal.Reset();
        else
           signal.Set();
    }
