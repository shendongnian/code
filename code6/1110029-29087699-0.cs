    public class MonitorJob : IJob
    {
        public MonitorJob(Worker1 worker1)
        {
            this._worker1 = worker1;
        }
        
        private readonly Worker1 _worker1;
        
        public void Execute(IJobExecutionContext context)
        {
            this._worker1.Callback();
        }
    }
