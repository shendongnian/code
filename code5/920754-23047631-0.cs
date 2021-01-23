    public void Subscribe(Handler subscriber)
    {
         WeakEventManager<Message, MessageArgType>
             .AddHandler(this, "subscribers", subscriber);
    }
