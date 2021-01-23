    public void Execute_DownCommand()
        {
           DownWorkTask = Task.Factory.StartNew(() =>
                    {
                        if (!Monitor.TryEnter(SyncRoot))
                        {
                            return;
                        } // Don't let  multiple threads in here at the same time.
        
                        try
                        {
                          // Do Something
                        }
                        finally
                        {
                            Monitor.Exit(SyncRoot);
                        }
                    });
        }
