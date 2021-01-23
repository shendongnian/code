    public class Mailbox
    {
        private ConcurrentQueue<Envelope> queue = new ConcurrentQueue<Envelope>();
    
        private int scheduled = 0;
        private volatile bool hasUnScheduledMessages = false;
        private WaitCallback run;
    
        public Mailbox ()
        {
            run = new WaitCallback(Run);
        }
    
        public void Run(object state)
        {
            Envelope tmp;
            while (queue.TryDequeue(out tmp))
            {
                //code to process each message
            }
    
            scheduled = 0;
            if (hasUnScheduledMessages)
            {
                hasUnScheduledMessages = false;
                Schedule();
            }
        }
    
        public void Post(Envelope m)
        {
            hasUnScheduledMessages = true;
            queue.Enqueue(m);
            Schedule();
        }
    
        private void Schedule()
        {
            //only schedule if we idle
            if (Interlocked.Exchange(ref scheduled, 1) == 0)
            {
                ThreadPool.QueueUserWorkItem(run);
            }
        }
    }
