    public static void DeleteDeadLetterMessage(string connectionString, string queueName, long sequenceNumber)
    {
        var deadLetterQueue = QueueClient.CreateFromConnectionString(connectionString, QueueClient.FormatDeadLetterPath(queueName));
        var msg = deadLetterQueue.Peek(sequenceNumber);
        if (msg.SequenceNumber == sequenceNumber)
        {
            msg = deadLetterQueue.Receive();
            msg.Complete();
        }
    }
