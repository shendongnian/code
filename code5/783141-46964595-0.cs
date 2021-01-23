    using System;
    using System.ServiceProcess;
    using System.Threading;
    partial class Service : ServiceBase
    {
        readonly AutoResetEvent StopEvent;
        readonly Thread Thread;
        public Service()
        {
            InitializeComponent();
            Thread = new Thread(ThreadStart);
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
            Thread.Start(parameter: TimeSpan.Parse(args[0]));
        }
        protected override void OnStop()
        {
            if (!StopEvent.Set())
                Environment.FailFast("failed setting stop event");
            Thread.Join();
        }
        void ThreadStart(object parameter)
        {
            while (!StopEvent.WaitOne(Timeout(startTime: (TimeSpan)parameter)))
            {
                // do work here...
            }
        }
        static TimeSpan Timeout(TimeSpan startTime)
        {
            var timeout = startTime - DateTime.Now.TimeOfDay;
            if (timeout < TimeSpan.Zero)
                timeout += TimeSpan.FromDays(1);
            return timeout;
        }
    }
