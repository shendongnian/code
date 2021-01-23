    public class ThreadManager
    {
        EventLoopScheduler _scheduler = new EventLoopScheduler();    
    
        public T ExecuteInWorkerThread<T>(Func<T> action)
        {
            return Observable.Start(action, _scheduler).Wait();
        }
    }
