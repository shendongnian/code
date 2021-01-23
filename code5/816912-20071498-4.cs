    public class TaskContinuation<TRet>
    {
        private readonly Task<TRet> _task;
        private readonly TaskScheduler _scheduler;
        public TaskContinuation(Task<TRet> task, TaskScheduler scheduler)
        {
            _task = task;
            _scheduler = scheduler;
        }
        public void ContinueWith(Action<Task<TRet>> func)
        {
            _task.ContinueWith(func, _scheduler);
        }
    }
