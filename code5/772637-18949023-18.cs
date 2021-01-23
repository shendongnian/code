    public class Program
    {
        public static void Main()
        {
            FireStarter.Execute();
        }
    }
    public class FireStarter
    {
        public static void Execute()
        {
            var setup = new JobDetailImpl("setup", "setupgroup", typeof(Setup));
            var midnight = new CronTriggerImpl("setuptrigger", "setuptriggergroup", 
                                               "setup", "setupgroup",
                                               DateTime.UtcNow, null, "0 0 0 * * ?");
            ScheduleManager.Instance.Schedule(setup, midnight);
        }
    }
