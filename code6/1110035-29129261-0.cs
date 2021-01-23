    public class MonitorJob<T> : IJob where T:IWorker
    {
        T worker;
        public MonitorJob(T worker)
        {
            this.worker = worker;
        }
        public void Execute(IJobExecutionContext context)
        {
            worker.Callback();
        }
    }
