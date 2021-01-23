    public static class ASyncHelper
    {
        public static void RunAsync(Func<Task> func)
        {
            var context = SynchronizationContext.Current;
            // you don't want to run it on a threadpool. So if it is null, 
            // you're not on a UI thread.
            if (context == null)
                throw new NotSupportedException(
                    "The current thread doesn't have a SynchronizationContext");
            context.Post(new SendOrPostCallback(async state => await func()), null);
        }
        public static void RunAsync<T>(Func<T, Task> func, T argument)
        {
            var context = SynchronizationContext.Current;
            // you don't want to run it on a threadpool. So if it is null, 
            // you're not on a UI thread.
            if (context == null)
                throw new NotSupportedException(
                    "The current thread doesn't have a SynchronizationContext");
            context.Post(new SendOrPostCallback(async state => await func((T)state)), argument);
        }
    }
