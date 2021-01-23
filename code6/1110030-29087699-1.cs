    public class MonitorJob : IJob
    {
        public MonitorJob([WithKey("Worker1")]ICallback callback)
        {
            this._callback = callback;
        }
        
        private readonly ICallback _callback;
        
        public void Execute(IJobExecutionContext context)
        {
            this._callback.Callback();
        }
    }
