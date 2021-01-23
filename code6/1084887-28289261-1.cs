        var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
        Task.Factory.StartNew(() => ContinueAsync(), CancellationToken.None, TaskCreationOptions.None, scheduler).
            Unwrap().
            ContinueWith(t => 
            {
                try
                {
                    t.GetAwaiter().GetResult();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    throw; // re-throw or handle somehow
                }
            }, CancellationToken.None, TaskContinuationOptions.None, scheduler);
