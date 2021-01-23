    public class MessageQueue : IDisposable
    {
        private readonly ConcurrentQueue<Message> _messages = new ConcurrentQueue<Message>();
        public int InQueue => _messages.Count;
        public int SendInterval { get; }
        private readonly Timer _sendTimer;
        private readonly ISendMessage _messageSender;
        public MessageQueue(ISendMessage messageSender, uint sendInterval) {
            _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
            SendInterval = (int)sendInterval;
            _sendTimer = new Timer(timerTick, this, Timeout.Infinite, Timeout.Infinite);
        }
        public void Start() {
            _sendTimer.Change(SendInterval, Timeout.Infinite);
        }
        private readonly ConcurrentQueue<Guid> _recentlyReceived = new ConcurrentQueue<Guid>();
        public void ResponseReceived(Guid id) {
            if (_recentlyReceived.Contains(id)) return; // We've already received a reply for this message
            // Store current message locally
            var message = _currentSendingMessage;
            if (message == null || id != message.MessageId)
                throw new InvalidOperationException($"Received response {id}, but that message hasn't been sent.");
            // Unset to signify that the message has been successfully sent
            _currentSendingMessage = null;
            // We keep id's of recently received messages because it's possible to receive a reply
            // more than once, since we're sending the message more than once.
            _recentlyReceived.Enqueue(id);
            if(_recentlyReceived.Count > 100) {
                _recentlyReceived.TryDequeue(out var _);
            }
        }
        public void Enqueue(Message m) {
            _messages.Enqueue(m);
        }
        // We may access this variable from multiple threads, but there's no need to lock.
        // The worst thing that can happen is we send the message again after we've already
        // received a reply.
        private Message _currentSendingMessage;
        private void timerTick(object state) {
            try {
                var message = _currentSendingMessage;
                // Get next message to send
                if (message == null) {
                    _messages.TryDequeue(out message);
                    // Store so we don't have to peek the queue and conditionally dequeue
                    _currentSendingMessage = message;
                }
                if (message == null) return; // Nothing to send
                // Send Message
                _messageSender.Send(message);
            } finally {
                // Only start the timer again if we're done ticking.
                try {
                    _sendTimer.Change(SendInterval, Timeout.Infinite);
                } catch (ObjectDisposedException) {
                }
            }
        }
        public void Dispose() {
            _sendTimer.Dispose();
        }
    }
    public interface ISendMessage
    {
        void Send(Message message);
    }
    public class Message
    {
        public Guid MessageId { get; }
        public string MessageData { get; }
        public Message(string messageData) {
            MessageId = Guid.NewGuid();
            MessageData = messageData ?? throw new ArgumentNullException(nameof(messageData));
        }
    }
