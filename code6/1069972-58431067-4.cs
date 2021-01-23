    public delegate Task AsyncEventHandler<in T>(T e) where T : AsyncEventArgs;
    public class AsyncEvent<T> where T : AsyncEventArgs
    {
        private string name;
        private List<AsyncEventHandler<T>> handlers;
        private Action<string, Exception> errorHandler;
        public AsyncEvent(string name, Action<string, Exception> errorHandler)
        {
            this.name = name;
            this.handlers = new List<AsyncEventHandler<T>>();
            this.errorHandler = errorHandler;
        }
        public void Register(AsyncEventHandler<T> handler)
        {
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));
            lock (this.handlers)
                this.handlers.Add(handler);
        }
        public void Unregister(AsyncEventHandler<T> handler)
        {
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));
            lock (this.handlers)
                this.handlers.Remove(handler);
        }
        public IReadOnlyList<AsyncEventHandler<T>> Handlers
        {
            get
            {
                var temp = default(AsyncEventHandler<T>[]);
                lock (this.handlers)
                    temp = this.handlers.ToArray();
                return temp.ToList().AsReadOnly();
            }
        }
        public async Task InvokeAsync(T ev)
        {
            var exceptions = new List<Exception>();
            foreach (var handler in this.Handlers)
            {
                try
                {
                    await handler(ev).ConfigureAwait(false);
                    if (ev.Handled)
                        break;
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }
            if (exceptions.Any())
                this.errorHandler?.Invoke(this.name, new AggregateException(exceptions));
        }
    }
