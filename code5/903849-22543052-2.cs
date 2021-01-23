    public static class TaskExt
    {
        public struct Void { }
    
        public static Task<Void> Convert(this Task @this)
        {
            return @this.ContinueWith(t =>
            {
                // propagate exceptions without wrapping
                t.GetAwaiter().GetResult(); 
                return default(Void);
            }, TaskContinuationOptions.ExecuteSynchronously);
        }
    }
