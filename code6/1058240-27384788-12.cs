    protected override void OnStop()
        {
            bool finishedSuccessfully = false;
            try
            {
                tokenSource.Cancel();
                var timeout = TimeSpan.FromSeconds(3);
                finishedSuccessfully = Task.Wait(backgroundTask, timeout);
            }
            finally
            {
                if (finishedSuccessfully == false)
                {
                    // Task didn't complete during reasonable amount of time
                    // Fix your cancellation handling in WorkerThreadFunc
                }
            }
        }
