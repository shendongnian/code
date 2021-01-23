    public interface ISubscription
    {
        Type Type { get;}
        String Message { get; set; }
        void InvokeMethod(object args);
    }
    public class Subscription<T> : ISubscription
    {
        public Type Type { get { return typeof(T); } }
        public string Message { get; set; }
        public Action<T> TypedCallback { get; set; }
        void ISubscription.InvokeMethod(object args)
        {
            if (!(args is T))
            {
                throw new ArgumentException(String.Concat("args is not type: ", typeof(T).Name), "args");
            }
            TypedCallback.Invoke((T)args);
        }
    }
    public static class Messenger
    {
        private static List<ISubscription> Subscribers { get; set; }
        static Messenger()
        {
            Subscribers = new List<ISubscription>();
        }
        public static void Subscribe<TPayload>(string message, Action<TPayload> callback)
        {
            //Add to the subscriber list
            Subscribers.Add(new Subscription<TPayload>()
            {
                Message = message,
                TypedCallback = callback
            });
        }
        public static void Send<TPayload>(string message, TPayload payload)
        {
            //Get all subscribers that match the message and payload type
            IEnumerable<ISubscription> subs = Subscribers.Where(x => x.Message == message && x.Type == typeof(TPayload));
            foreach (ISubscription sub in subs)
                sub.InvokeMethod(payload);
                
        }
    }
