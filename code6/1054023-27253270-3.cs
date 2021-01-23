    public class MessageSender : ISendMessages
    {
        public Task SendAsync(TransportMessage message, SendOptions options)
        {
            return Transaction.Current.EnlistVolatileAsync
                   (new SendResourceManager(async () => 
                                           { await sender.SendAsync(message) }));
        }
    }
