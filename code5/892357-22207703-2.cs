    public class Program
    {
        static void Main(string[] args) {
            try {
                const int TotalMessageCount = 1000;
                var messageSender = new SimulatedMessageSender();
                using (var messageQueue = new MessageQueue(messageSender, 10)) {
                    messageSender.Initialize(messageQueue);
                    for (var i = 0; i < TotalMessageCount; i++) {
                        messageQueue.Enqueue(new Message(i.ToString()));
                    }
                    var startTime = DateTime.Now;
                    Console.WriteLine("Starting message queue");
                    messageQueue.Start();
                    while (messageQueue.InQueue > 0) {
                        Thread.Yield(); // Want to use Thread.Sleep or Task.Delay in the real world.
                    }
                    var endTime = DateTime.Now;
                    var totalTime = endTime - startTime;
                    var messagesPerSecond = TotalMessageCount / totalTime.TotalSeconds;
                    Console.WriteLine($"Messages Per Second: {messagesPerSecond:#.##}");
                }
            } catch (Exception ex) {
                Console.Error.WriteLine($"Unhandled Exception: {ex}");
            }
            Console.WriteLine();
            Console.WriteLine("==== Done ====");
            Console.ReadLine();
        }
    }
    public class SimulatedMessageSender : ISendMessage
    {
        private MessageQueue _queue;
        public void Initialize(MessageQueue queue) {
            if (_queue != null) throw new InvalidOperationException("Already initialized.");
            _queue = queue ?? throw new ArgumentNullException(nameof(queue));
        }
        private static readonly Random _random = new Random();
        public void Send(Message message) {
            if (_queue == null) throw new InvalidOperationException("Not initialized");
            var chanceOfFailure = _random.Next(0, 20);
            // Drop 1 out of 20 messages
            // Most connections won't even be this bad.
            if (chanceOfFailure != 0) {
                _queue.ResponseReceived(message.MessageId);
            }
        }
    }
