    internal class Setup : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            try
            {                
                foreach (var kvp in DbMock.ScheduleMap)
                {
                    var email = kvp.Value;
                    var notify = new JobDetailImpl(email, "emailgroup", typeof(Notify))
                        {
                            JobDataMap = new JobDataMap {{"email", email}}
                        };
                    var time = new DateTimeOffset(DateTime.Parse(kvp.Key).ToUniversalTime());
                    var trigger = new SimpleTriggerImpl(email, "emailtriggergroup", time);
                    ScheduleManager.Instance.Schedule(notify, trigger);
                }
                Console.WriteLine("{0}: all jobs scheduled for today", DateTime.Now);
            }
            catch (Exception e) { /* log error */ }           
        }
    }
