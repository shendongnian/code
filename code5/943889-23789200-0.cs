    public class NotThreadSafeClass
    {
        public int SomeMethod(string x, int y)
        {
            return 3;
        }
    }
    public class ThreadSafeWrapper
    {
        private TaskScheduler sta = new StaTaskScheduler(numberOfThreads: 1);
        private NotThreadSafeClass old = new NotThreadSafeClass();
        public Task<int> SomeMethod(string x, int y)
        {
            return Task<int>.Factory.StartNew(() => old.SomeMethod(x,y),
                 CancellationToken.None, TaskCreationOptions.None, sta);
        }
    }
