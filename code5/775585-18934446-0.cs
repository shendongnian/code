    class Producer
    {
        public readonly Timer timer;
        public ConcurrentQueue<int> Queue {get;private set;}
    
        Producer()
        {
            timer = new Timer(Callback, null, 0, 8);
            Queue = new Concurrent<int>();
        }
    
        private void Callback(object state)
        {
            Queue.Enqueue(123);
        }
    }
    
    class Consumer
    {
        private readonly Producer producer;
        private readonly DispatcherTimer timer;
    
        Consumer(Producer p)
        {
            producer = p;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(33);
            timer.Tick += new EventHandler(dispatcherTimer_Tick);
            timer.Start();
        }
    
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            int value;
            if(producer.Queue.TryDequeue(out value))
            {
                // Update your UI here
            }
        }
    }
