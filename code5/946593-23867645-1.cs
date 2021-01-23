    const string queueName = @".\BGQueue";
    MessageQueue messageQueue = new MessageQueue(queueName);
    Message[] messages = messageQueue.GetAllMessages();
    foreach (System.Messaging.Message message in messages)
    {
        //process the message, insert/update SQL etc.
    }
    messageQueue.Purge(); //cleanup the queue once done.
