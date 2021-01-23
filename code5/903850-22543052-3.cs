    public struct Empty 
    { 
        public static readonly Empty Value = default(Empty); 
    }
	
    public static class TaskExt
    {
        public static Task<Empty> Convert(this Task @this)
        {
            return @this.ContinueWith(t =>
            {
                // propagate exceptions without wrapping
                t.GetAwaiter().GetResult();
                return Empty.Value;
            }, TaskContinuationOptions.ExecuteSynchronously);
        }
    }
