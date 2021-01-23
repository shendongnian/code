    public void Execute_UpCommand()
        {
           DownWorkTask.Wait(); // The release waits for the pressed work completion and starts without locking the UI
           
           Task.Factory.StartNew(() =>
            {
                if (!Monitor.TryEnter(SyncRoot))
                {
                    return;
                } // Don't let  multiple threads in here at the same time.
                try
                {
                    // Do Up Work
                }
                finally
                {
                    Monitor.Exit(SyncRoot);
                }
            });
        }
