    public static class AsynchronousEventExtensions
    {
        public static Task Raise<TSource, TEventArgs>(this Func<TSource, TEventArgs, Task> handlers, TSource source, TEventArgs args)
            where TEventArgs : EventArgs
        {
            if (handlers != null)
            {
                return Task.WhenAll(handlers.GetInvocationList()
                    .OfType<Func<TSource, TEventArgs, Task>>()
                    .Select(h => h(source, args)));
            }
            return Task.CompletedTask;
        }
    }
