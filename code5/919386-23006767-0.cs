    using System.Collections.Concurrent;
    using System.Threading;
    class LoadBalancedContext : SynchronizationContext
    {
        readonly Thread thread1;
        readonly Thread thread2;
        readonly ConcurrentQueue<JobInfo> jobs = new ConcurrentQueue<JobInfo>();
        public LoadBalancedContext()
        {
            this.thread1 = new Thread(this.Poll) { Name = "T1" };
            this.thread2 = new Thread(this.Poll) { Name = "T2" };
            this.thread1.Start();
            this.thread2.Start();
        }
        public override void Post(SendOrPostCallback d, object state)
        {
            this.jobs.Enqueue(new JobInfo { Callback = d, State = state });
        }
        void Poll()
        {
            while (true)
            {
                JobInfo info;
                if (this.jobs.TryDequeue(out info))
                {
                    info.Callback(info.State);
                }
                Thread.Sleep(100);
            }
        }
        class JobInfo
        {
            public SendOrPostCallback Callback { get; set; }
            public object State { get; set; }
        }
    }
