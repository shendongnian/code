    using System;
    using System.ServiceProcess;
    using System.Threading;
    partial class Service : ServiceBase
    {
        Thread Thread;
        readonly AutoResetEvent StopEvent;
        public Service()
        {
            InitializeComponent();
            StopEvent = new AutoResetEvent(initialState: false);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                StopEvent.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }
        protected override void OnStart(string[] args)
        {
            Thread = new Thread(ThreadStart);
            
            Thread.Start(TimeSpan.Parse(args[0]));
        }
        protected override void OnStop()
        {
            if (!StopEvent.Set())
                Environment.FailFast("failed setting stop event");
            Thread.Join();
        }
        void ThreadStart(object parameter)
        {
            while (!StopEvent.WaitOne(Timeout(timeOfDay: (TimeSpan)parameter)))
            {
                // do work here...
            }
        }
        static TimeSpan Timeout(TimeSpan timeOfDay)
        {
            var timeout = timeOfDay - DateTime.Now.TimeOfDay;
            if (timeout < TimeSpan.Zero)
                timeout += TimeSpan.FromDays(1);
            return timeout;
        }
    }
