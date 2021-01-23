      CancellationTokenSource cts;
      void Start()
      {
            cts = new CancellationTokenSource();
            // run async operation
            var task = Task.Run(() => SomeWork(cts.Token), cts.Token);
            // wait for completion
            // after the completion handle the result/ cancellation/ errors
        }
        async Task<int> SomeWork(CancellationToken cancellationToken)
        {
            int result = 0;
            bool loopAgain = true;
            while (loopAgain)
            {
                // do something ... means a substantial work or a micro batch here - not processing a single byte
                
                loopAgain = /* check for loop end && */  cancellationToken.IsCancellationRequested;
                if (loopAgain) {
                    // reschedule  the task to the threadpool and free this thread for other waiting tasks
                    await Task.Yield();
                }
            }
            cancellationToken.ThrowIfCancellationRequested();
            return result;
        }
        void Cancel()
        {
            // request cancelation
            cts.Cancel();
        }
