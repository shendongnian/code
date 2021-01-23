    public class MyClass : IDisposable
    {
        private readonly CancellationTokenSource feedCancellationTokenSource =
            new CancellationTokenSource();
        private readonly Task feedTask;
        public MyClass()
        {
            feedTask = Task.Factory.StartNew(() =>
            {
                while (!feedCancellationTokenSource.IsCancellationRequested)
                {
                    // do finite work
                }
            });
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                feedCancellationTokenSource.Cancel();
                feedTask.Wait();
                feedCancellationTokenSource.Dispose();
                feedTask.Dispose();
            }
        }
    }
