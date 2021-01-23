    private void OnMessageProcessed(IrcMessage message, IrcCommand command, ICommandFormatter response)
    {
        this.OnMessageProcessed(message);
        ServerMessage formattedMessage = (ServerMessage)response.FormatMessage(message, command);
        this.PushMessage(formattedMessage);
    }
    private void PushMessage<T>(T notification) where T : IMessage
    {
        this.notificationManager.Publish(notification);
    }
