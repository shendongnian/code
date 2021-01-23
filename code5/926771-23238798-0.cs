    public class Scheduler
    {
        public bool ScheduleTask(string taskname, DateTime startTime, DateTime endTime)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(taskname));
            Contract.Requires(startTime != null);
            Contract.Requires(endTime != null);
            return true;
        }
    }
