    public Task<List<Thing>> Produce(Message message)
    {
        //...
    }
    
    public Task Consume(List<Thing> data)
    {
        //...
    }
    
    public async Task MessageReceived(Message message)
    {
        while(HaveMoreBatches(message))
        {
            await Consume(await Produce(message));
        }
    }
