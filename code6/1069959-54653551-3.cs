    public static class AsynchronousEventExtensions
    {
        public static async Task Raise<TSource, TEventArgs>(this Func<TSource, TEventArgs, Task> handlers, TSource source, TEventArgs args)
            where TEventArgs : EventArgs
        {
            if (handlers != null)
            {
                foreach (Func<TSource, TEventArgs, Task> handler in handlers.GetInvocationList())
                {
                    await handler(source, args);
                }
            }
        }
    }
