    public static class TranscationExtensions
    {
        public static Task EnlistVolatileAsync(this Transaction transaction, 
                                               IEnlistmentNotification 
                                               enlistmentNotification, 
                                               EnlistmentOptions enlistmentOptions)
        {
            return Task.FromResult(transaction.EnlistVolatile
                                               (enlistmentNotification, 
                                                enlistmentOptions));
        }
    }
