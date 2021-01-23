    public void RunWorkerAsync(object argument)
        {
            if (isRunning)
            {
                throw new InvalidOperationException(SR.GetString(SR.BackgroundWorker_WorkerAlreadyRunning));
            }
      
            isRunning = true;
            cancellationPending = false;
      
            asyncOperation = AsyncOperationManager.CreateOperation(null);
            threadStart.BeginInvoke(argument,
                                    null,
                                    null);
        }
