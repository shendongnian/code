    private static void Main(string[] args)
    {
        var actionBlock = new ActionBlock<BrokeredMessage>(async message =>
                                                           await
                                                         ProcessCalculationsAsync(message));
    	var produceMessagesTask = Task.Run(async () => await
                                                       ProduceBrokeredMessagesAsync(client, 
                                                       actionBlock));
    	
    	produceMessagesTask.Wait();
    }
