    public class MyMessageListeners : IMyMessageListeners
    {
        readonly List<IMyMessageReceiver> _list = new List<IMyMessageReceiver>();
        public void Add(IMyMessageReceiver receiver)
        {
            _list.Add(receiver);
        }
        public void Send(IMyMessage message)
        {
            foreach (var listener in _list)
                listener.HandleMessage(message);
        }
    }
