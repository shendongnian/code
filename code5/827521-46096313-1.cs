    public async Task DeleteDeadLetterMessageAsync(string connectionString, string queueName, long sequenceNumber)
    {
        var deadLetterQueue = QueueClient.CreateFromConnectionString(connectionString, QueueClient.FormatDeadLetterPath(queueName));
        var msg = await deadLetterQueue.PeekAsync(sequenceNumber);
        if (msg.SequenceNumber == sequenceNumber)
        {
            msg = await deadLetterQueue.ReceiveAsync();
            await msg.CompleteAsync();
        }
    }
