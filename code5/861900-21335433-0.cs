    class Program
    {
        static BlockingCollection<string> _signalStore = new BlockingCollection<string>();
        static void Listener()
        {
            while(true)
            {
                var message = _signalStore.Take();
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + ": " + message);
            }
        }
        static void Sender()
        {
            var counter = 0;
            while(true)
            {
                _signalStore.Add(counter++.ToString());
                Thread.Sleep(100);
            }
        }
        static void Main(string[] args)
        {
            var listenerCount = 5;
            for (var i = 0;  i < listenerCount; i++)
            {
                var newListnerTask = new Task(Listener);
                newListnerTask.Start();
            }
            var newSenderTask = new Task(Sender);
            newSenderTask.Start();
            Console.ReadKey();
        }
    }
