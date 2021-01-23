    public void SaveMessage(Message message)
    {
         messageContext.Messages.Add(message);
        _messageRepository.Save();
    }
