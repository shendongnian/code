    public async Task<IEnumerable<BrokeredMessage>> GetDeadLetterMessagesAsync(string connectionString,
        string queueName)
    {
        var queue = QueueClient.CreateFromConnectionString(connectionString, QueueClient.FormatDeadLetterPath(queueName));
        var messageList = new List<BrokeredMessage>();
        BrokeredMessage message;
        do
        {
            message = await queue.PeekAsync();
            if (message != null)
            {
                messageList.Add(message);
            }
        } while (message != null);
        return messageList;
    }
