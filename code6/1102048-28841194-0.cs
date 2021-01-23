    public void SubscribeToMessages(Action<object, EventArgs> eventHandler)
    {
        this.MessageReceived += new EventHandler<EventArgs>(eventHandler);
    }
    public void UnsubscribeFromMessages(Action<object, EventArgs> eventHandler)
    {
        this.MessageReceived -= new EventHandler<EventArgs>(eventHandler);
    }
