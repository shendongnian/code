    class Program
    {
        static void Main(string[] args)
        {
            var notificationManager = new NotificationManager();
            ISubscription subscription = notificationManager.Subscribe<ServerMessage>(
                (message, sub) => Console.WriteLine(message.Content));
            notificationManager.Publish(new ServerMessage("This works"));
            IMessage newMessage = MessageFactoryMethod("This works without issue.");
            notificationManager.Publish(newMessage);
            Console.ReadKey();
        }
        private static IMessage MessageFactoryMethod(string content)
        {
            return new ServerMessage(content);
        }
    }
