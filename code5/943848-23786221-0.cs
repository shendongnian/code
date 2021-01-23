    IMessage message = MessageFactory.CreateMessage("incomingA");
    
         if (!(message is IIncommingMessage))
            throw new InvalidOperationException();
         (message as IIncommingMessage).ProcessMessage();
