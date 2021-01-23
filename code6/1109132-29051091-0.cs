    void subscribe(List<Type> listMessagesTypes, Action doAction)
    {
       foreach (Type messageType in listMessagesTypes)         
         if (typeof(IMessage).IsAssignableFrom(messageType)
           _messenger.subscribe(messageType, doAction);
    }
