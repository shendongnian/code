    public class BaseJob : IJob
    {
        public virtual void Execute(IJobExecutionContext context)
        {
            JobKey jobKey = context.JobDetail.Key;
            string message = string.Format("Job Key:{0} - Trigger Key:{1} - Start Time:{2} - Schedule Fire Time: {3}", context.JobDetail.Key, context.Trigger.Key, context.Trigger.StartTimeUtc, context.ScheduledFireTimeUtc);
            ILog log = LogManager.GetCurrentClassLogger();
            log.Debug(message);
            Console.WriteLine(new String('*', 100));
            Console.WriteLine("Trigger Info: " + message);
            Console.WriteLine("Next Schedule: " + context.Trigger.GetNextFireTimeUtc());
            Console.WriteLine(new String('*', 100));
        }
        public string Name { get; set; }
        public string Group { get; set; }
        public Type Type { get; set; }
    }
