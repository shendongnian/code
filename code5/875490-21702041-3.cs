    // don't use this in production
    public static class SwitchContext
    {
        public static Awaiter Yield() { return new Awaiter(); }
    
        public struct Awaiter : System.Runtime.CompilerServices.INotifyCompletion
        {
            public Awaiter GetAwaiter() { return this; }
    
            public bool IsCompleted { get { return false; } }
    
            public void OnCompleted(Action continuation)
            {
                ThreadPool.QueueUserWorkItem((state) => ((Action)state)(), continuation);
            }
    
            public void GetResult() { }
        }
    }
    // ...
    await SwitchContext.Yield();
