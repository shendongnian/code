    // the queue
    private BlockingCollection<Message> MessagesQueue = new BlockingCollection<Message>();
    // the consumer
    private MessageParser()
    {
        foreach (var msg in MessagesQueue.GetConsumingEnumerable())
        {
            var parsedMessage = ParseMessage(msg);
            // do something with the parsed message
        }
    }
    // In your main program
    // start the consumer
    var consumer = Task.Factory.StartNew(() => MessageParser(),
        TaskCreationOptions.LongRunning);
    // the main loop
    while (messageAvailable)
    {
        var msg = GetMessageFromTcp();
        // add it to the queue
        MessagesQueue.Add(msg);
    }
    // done receiving messages
    // tell the consumer that no more messages will be added
    MessagesQueue.CompleteAdding();
    // wait for consumer to finish
    consumer.Wait();
