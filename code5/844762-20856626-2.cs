    private async Task<Message> MyReceiveAsync()
    {
        MessageQueue queue=new MessageQueue();
        ...
        var message=await Task.Factory.FromAsync<Message>(
                           queue.BeginReceive(),
                           queue.EndReceive);
        return message;
    }
    public async Task LogToDB()
    {
        while(true)
        {
           var message=await MyReceiveAsync();
           SaveMessage(message);
        }
    }
