    public bool Publish(byte[] data)
    {
        //..
        bool successful = false;
        var responseReceivedEvent = new ManualResetEvent(false);
        channel.BasicAcks += (model, args) => 
        { 
            successful = true; 
            responseReceivedEvent.Set(); 
        };
        channel.BasicNacks += (model, args) =>
        { 
            successful = false; 
            responseReceivedEvent.Set(); 
        };
        channel.BasicPublish("", "test", null, data);
        responseReceivedEvent.WaitOne();
        return successful;
    }
