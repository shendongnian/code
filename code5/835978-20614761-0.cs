    const int MAX_QUEUE_LENGTH = 10;
    private BlockingCollection<MyMessageContainer> messageQueue = new BlockingCollection<MyMessageContainer>(new ConcurrentQueue<MyMessageContainer>(), MAX_QUEUE_LENGTH);
    
    void ProcessMessages()
    {
        foreach (var message in messageQueue.GetConsumingEnumerable())
        {
            if(soc.Connected == false)
                break;
    
            soc.Send(message.ToPaylod());
        }
    }
