    private readonly MessageQueue _failQueue;
    private readonly MessageQueue _messageQueue;
    /* Other code here (cursor, peek action, run method, initialization etc) */
    private void dumpToFailQueue(Message message)
    {
        var oldId = message.Id;
        _failQueue.Send(message, MessageQueueTransactionType.Single);
        // Remove the poisoned message
        _messageQueue.ReceiveById(oldId);
    }
    private void moveToEnd(Message message)
    {
        var oldId = message.Id;
        _messageQueue.Send(message, MessageQueueTransactionType.Single);
        // Remove the poisoned message
        _messageQueue.ReceiveById(oldId);
    }
