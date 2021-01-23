    internal class Notification<TMessage> : INotificationProcessor, INotification<TMessage> where TMessage : class, IMessage
    {
        private Action<TMessage, ISubscription> callback;
        public void Register(Action<TMessage, ISubscription> callbackMethod)
        {
            this.callback = callbackMethod;
        }
        public void Unsubscribe()
        {
            this.callback = null;
        }
        public void ProcessMessage(IMessage message)
        {
            // I can now cast my IMessage to T internally. This lets
            // subscribers use this and not worry about handling the cast themselves. 
            this.callback(message as TMessage, this);
        }
    }
