    class Model
    {
        private readonly SynchronizationContext _synchronizationContext;
        private readonly IConnection _connection;
        public Model()
        {
             // Capture UI synchronization context.
             // Note: this assumes that Model is constructed on the UI thread.
             _synchronizationContext = SynchronizationContext.Current; 
            _connection = new DevConnection(MessageCallback);
        }
        private void MessageCallback(string payload)
        {
            // schedule UI update on the UI thread.
            _synchronizationContext.Post(
                new SendOrPostCallback(ctx => Message(payload)),
                null);            
        }
        private void Message(string payload)
        {
            ...
            _volume1 = floatValue;
            ...
        }
    }
