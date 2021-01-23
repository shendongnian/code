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
    void GenerateMessageOne()
    {
        while(true)
        {
            messageQueue.Add(new MyMessageContainer("A"));
        }
    }
    void GenerateMessageTwo()
    {
        while(true)
        {
            messageQueue.Add(new MyMessageContainer("1"));
        }
    }
    class MyMessageContainer
    {
         public MyMessageContainer(string message)
         {
              _message = message;
         }
         private string _message;
         public byte[] ToPayload()
         {
             var lengthBytes = BitConverter.GetBytes(byData.Length);
             return lengthBytes.Concat(() => System.Text.Encoding.ASCII.GetBytes(_message)).ToArray();
         }
    }
