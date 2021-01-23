    public MessageContext messageContext = new MessageContext();
    public UserService()
    {
        _messageRepository = new MessageRepository(messageContext);
    }
