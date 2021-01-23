    public delegate void SyncDelegatesInParallelDelegate<in T>(T item);
    public static class ParallelLinqExtensions
    {
        public static void SyncDelegatesInParallel<T>(
            this IEnumerable<T> list, 
            SyncDelegatesInParallelDelegate<T> action)
        {
            var foundCriticalException = false;
            Exception exception = null;
            var waitHndls = new List<WaitHandle>();
            foreach (var item in list)
            {
                // Temp copy of session for modified closure
                var localItem = item;
                var txEvnt = new ManualResetEvent(false);
                // Temp copy of session for closure
                ThreadPool.QueueUserWorkItem(
                     depTx =>
                     {
                         try { if (!foundCriticalException) action(localItem); }
                         catch (Exception gX) 
                         { exception = gX; foundCriticalException = true; }
                         finally { txEvnt.Set(); }
                     }, null);
                waitHndls.Add(txEvnt);
            }
            if (waitHndls.Count > 0) WaitHandle.WaitAll(waitHndls.ToArray());
            if (exception != null) throw exception;
        }
    }
