    public class RequestQueue
    {
        private readonly Queue<HttpRequest> _requestHistory; 
        private RequestQueue()
        {
            _requestHistory = new Queue<HttpRequest>();
        }
        private static RequestQueue _singleton;
        public static RequestQueue Instance()
        {
            if (_singleton == null)
                _singleton = new RequestQueue();
            return _singleton;
        }
        public void Enqueue(HttpRequest request)
        {
            _requestHistory.Enqueue(request);
        }
        public void Flush()
        {
            while (_requestHistory.Count > 0)
            {
                var request = _requestHistory.Dequeue();
                try
                {
                    //Write request To Db
                }
                catch (Exception)
                {
                    _requestHistory.Enqueue(request);
                }
            }
        }
    }
    public class WebApiApplication : System.Web.HttpApplication
    {
        public WebApiApplication()
        {
            base.BeginRequest += delegate
                {
                    RequestQueue.Instance().Enqueue(HttpContext.Current.Request);
                };
        }
        private void InitializeQuartz()
        {
            ISchedulerFactory sf = new StdSchedulerFactory();
            IScheduler sched = sf.GetScheduler();
            DateTimeOffset runTime = DateBuilder.EvenMinuteDate(DateTime.UtcNow);
            DateTimeOffset startTime = DateBuilder.NextGivenSecondDate(null, 5);
            IJobDetail job = JobBuilder.Create<QueueConsumer>()
                .WithIdentity("job1", "group1")
                .Build();
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartAt(runTime)
                .WithCronSchedule("5 0/1 * * * ?")
                .Build();
            sched.ScheduleJob(job, trigger);
            sched.Start();
        }
        public class QueueConsumer : IJob
        {
            public void Execute(IJobExecutionContext context)
            {
                RequestQueue.Instance().Flush();
            }
        }
        protected void Application_Start()
        {
            InitializeQuartz();
