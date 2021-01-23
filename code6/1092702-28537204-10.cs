    // Message
    public abstract class MessageBase
    {
        public virtual void Action() // ...for examples sake
        {
            Console.WriteLine(GetType().Name);
        }
    }
    // Message handler
    public interface IMessageHandler
    {
        void Execute<T>(T message) where T : MessageBase;
    }
    // Resolver
    public static class HandlerRegistry
    {
        private static readonly Dictionary<string, Type> Handlers = 
            new Dictionary<string, Type>();
        public static void Register<T, T2>() where T2 : IMessageHandler
        {
            Handlers.Add(typeof(T).FullName, typeof(T2));
        }
        public static IMessageHandler Resolve<T>(T parameters)
        {
            var type = Handlers[parameters.GetType().FullName];
            return (IMessageHandler)Activator.CreateInstance(type);
        }
    }
