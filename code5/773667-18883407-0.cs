    class Program
    {
        static void Main(string[] args)
        {
            var multicaster = new QueueMulticaster<int>();
            
            var listener1 = new Listener(); //Make a couple of listening Q objects. 
            listener1.Listen();
            multicaster.Subscribe(listener1);
            
            var listener2 = new Listener();
            listener2.Listen();
            multicaster.Subscribe(listener2);
            multicaster.Broadcast(6); //Send a 6 to both concurrent Queues. 
            Console.ReadLine();
        }
    }
    //The listeners would run on their own thread and poll the Q like crazy. 
    class Listener : IListenToStuff<int>
    {
        public ConcurrentQueue<int> StuffQueue { get; set; }
        public void Listen()
        {
            StuffQueue = new ConcurrentQueue<int>();
            var t = new Thread(ListenAggressively);
            t.Start();
            
        }
        void ListenAggressively()
        {
            while (true)
            {
                int val;
                if(StuffQueue.TryDequeue(out val))
                    Console.WriteLine(val);
            }
        }
    }
    //Simple class that allows you to subscribe a Queue to a broadcast event. 
    public class QueueMulticaster<T>
    {
        readonly List<IListenToStuff<T>> _subscribers = new List<IListenToStuff<T>>();
        public void Subscribe(IListenToStuff<T> subscriber)
        {
            _subscribers.Add(subscriber);
        }
        public void Broadcast(T value)
        {
            foreach (var listenToStuff in _subscribers)
            {
                listenToStuff.StuffQueue.Enqueue(value);
            }
        }
    }
    public interface IListenToStuff<T>
    {
        ConcurrentQueue<T> StuffQueue { get; set; }
    }
