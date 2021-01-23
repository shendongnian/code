    internal class ScheduleManager
    {
        private static readonly ScheduleManager _instance = new ScheduleManager();
        private readonly IScheduler _scheduler;
        private ScheduleManager()
        {
            var properties = new NameValueCollection();
            properties["quartz.scheduler.instanceName"] = "notifier";
            properties["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz";
            properties["quartz.threadPool.threadCount"] = "5";
            properties["quartz.threadPool.threadPriority"] = "Normal";
            var sf = new StdSchedulerFactory(properties);
            _scheduler = sf.GetScheduler();
            _scheduler.Start();
        }
        public static ScheduleManager Instance
        {
            get { return _instance; }
        }
        public void Schedule(IJobDetail job, ITrigger trigger)
        {
            _scheduler.ScheduleJob(job, trigger);
        }
        public void Unschedule(TriggerKey key)
        {
            _scheduler.UnscheduleJob(key);
        }
    }
