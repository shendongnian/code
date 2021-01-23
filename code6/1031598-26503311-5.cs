    public void Method() {
        // Operation One:
        CommitAsync().ContinueWith(
            t => { 
                Console.WriteLine(
                    "Committing failed in the background: {0}", 
                    t.Exception.Message
                );
            }, 
            TaskContinuationOptions.OnlyOnFaulted
        );
        // Operation Two.
    }
