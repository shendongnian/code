    public delegate Task AsyncEventHandler(AsyncEventArgs e);
    public class AsyncEventArgs : System.EventArgs
    {
        public bool Handled { get; set; }
    }
    
    public class AsyncEvent
    {
        private string name;
        private List<AsyncEventHandler> handlers;
        private Action<string, Exception> errorHandler;
    
        public AsyncEvent(string name, Action<string, Exception> errorHandler)
        {
            this.name = name;
            this.handlers = new List<AsyncEventHandler>();
            this.errorHandler = errorHandler;
        }
    
        public void Register(AsyncEventHandler handler)
        {
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));
    
            lock (this.handlers)
                this.handlers.Add(handler);
        }
    
        public void Unregister(AsyncEventHandler handler)
        {
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));
    
            lock (this.handlers)
                this.handlers.Remove(handler);
        }
    
        public IReadOnlyList<AsyncEventHandler> Handlers
        {
            get
            {
                var temp = default(AsyncEventHandler[]);
    
                lock (this.handlers)
                    temp = this.handlers.ToArray();
    
                return temp.ToList().AsReadOnly();
            }
        }
    
        public async Task InvokeAsync()
        {
            var ev = new AsyncEventArgs();
            var exceptions = new List<Exception>();
    
            foreach (var handler in this.Handlers)
            {
                try
                {
                    await handler(ev).ConfigureAwait(false);
    
                    if (ev.Handled)
                        break;
                }
                catch(Exception ex)
                {
                    exceptions.Add(ex);
                }
            }
    
            if (exceptions.Any())
                this.errorHandler?.Invoke(this.name, new AggregateException(exceptions));
        }
    }
