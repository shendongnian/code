    void RegisterNotification(TaskCompletionSource<object> tcs)
    {
        this.source.NotificationEvent += (s, eData) => 
        {
            Debug.WriteLine("A.before");
    
            try
            {
                var oldContext = SynchronizationContext.Current;
                var newContext = new SynchronizationContext();
                SynchronizationContext.SetSynchronizationContext(newContext);
    
                tcs.TrySetResult(eData.Result);
            }
            finally
            {
                SynchronizationContext.SetSynchronizationContext(oldContext);
            }
    
            Debug.WriteLine("A.after");
    
            DoProcessingA();
        };   
    }
