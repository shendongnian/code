    try
        {
        MessageReceiver fromQueueClient = null;
            MessagingFactory factory = MessagingFactory.CreateFromConnectionString(connectionString);
            fromQueueClient = await factory.CreateMessageReceiverAsync(_entityName, ReceiveMode.PeekLock);
                BrokeredMessage _message = await fromQueueClient.ReceiveAsync(SequenceNumber);
             
                    await _message.CompleteAsync();
        }
        catch (Exception ex)
        {
        }
        finally
        {
                await fromQueueClient.CloseAsync();
        }
  
