    public sealed class Q : IDisposable
    {
        private CancellationTokenSource cts = new CancellationTokenSource();
        private BlockingCollection<Action> queue =
            new BlockingCollection<Action>(new ConcurrentQueue<Action>());
        private static Lazy<Q> LazyQ = new Lazy<Q>(()=>new Q());
        public static Q Queue { get { return LazyQ.Value; } }
        public Q()
        {
            new Thread(() => RunQueue()).Start();
        }
        private void RunQueue()
        {
            while (!cts.IsCancellationRequested)
            {
                Action action;
                try
                {
                    //lovely... blocks until something is available
                    //so we don't need to deal with messy synchronization
                    action = queue.Take(cts.Token);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                action();
                
            }
        }
        public Task RunActionInQueueAsync(Action action)
        {
            var tcs=new TaskCompletionSource<int>();
            Action act = () =>
                {
                    try
                    {
                        action();
                        tcs.SetResult(0);
                    }
                    catch (Exception ex)
                    {
                        
                        tcs.SetException(ex);
                    }
                    
                    
                };
            try
            {
                queue.Add(act, cts.Token);
            }
            catch (OperationCanceledException e)
            {
                throw new ObjectDisposedException("Q is disposed", e);
            }
            return tcs.Task;
        }
        public void Dispose()
        {
            if (!cts.IsCancellationRequested)
            {
                cts.Cancel();
            }
        }
    }
