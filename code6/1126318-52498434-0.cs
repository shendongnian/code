    public async void DeleteMessagesFromQueueAsync()
    {
        bool isDeadLetter=true;
        long SequenceNumber = 12;
        string queuePath='queue name';
        string connectionString='connection string of ASB Namespace';
        BrokeredMessage _srcMessage = null;
        DeleteMessageResponse _msgDeletionStatus = new DeleteMessageResponse();
        MessageReceiver fromQueueClient = null;
        try
        {
            MessagingFactory factory = MessagingFactory.CreateFromConnectionString(connectionString);
            string _fromEntityPath = !isDeadLetter ? queuePath : QueueClient.FormatDeadLetterPath(queuePath);
            fromQueueClient = await factory.CreateMessageReceiverAsync(_fromEntityPath, ReceiveMode.PeekLock);
                BrokeredMessage _message = await fromQueueClient.ReceiveAsync(SequenceNumber);
                if (_message != null)
                    _srcMessage= _message;
            if (_srcMessage != null )
            {  
                    await _srcMessage.CompleteAsync();
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
            if (fromQueueClient != null)
                await fromQueueClient.CloseAsync();
        }
    }
