    public interface IMessageHandler
    {
        void SendMessage(string msg);
    }
    public class MessageHandler : IMessageHandler
    {
        public ObservableCollection<string> Messages { get; set; }
        public void SendMessage(string msg)
        {
            App.Current.Dispatcher.BeginInvoke(new Action(() => Messages.Add(msg)));
        }
    }
    public class ViewModel1 
    {
        private readonly IMessageHandler _messageHandler;
        public ViewModel1(IMessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
        }
    }
    public class ViewModel2 
    {
        private readonly IMessageHandler _messageHandler;
        public ViewModel2(IMessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
        }
    }
