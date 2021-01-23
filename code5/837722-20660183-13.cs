    public interface IMyMessageListeners
    {
        void Add(IMyMessageReceiver receiver);
        // I added this since I think this is how you're going to use it
        void Send(IMyMessage message);
    }
