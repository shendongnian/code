    class AsyncSemaphore
    {
        public AsyncSemaphore(int counter, int maxCounter)
        {
            this.maxCounter = maxCounter;
            this.counter = counter;
        }
        private int maxCounter, counter;
        class CallbackObject:IAsyncResult
        {
            private AsyncCallback callback;
            #region IAsyncResult Members
            public object AsyncState { get; set; }
            public System.Threading.WaitHandle AsyncWaitHandle
            {
	            get 
                {
                    throw new NotImplementedException();
                }
            }
            public bool CompletedSynchronously { get; set; }
            public bool IsCompleted { get; set; }
            public AsyncCallback Callback
            {
                get { return callback; }
                set { callback = value; }
            }
            #endregion
        }
        private ConcurrentQueue<CallbackObject> queue = new ConcurrentQueue<CallbackObject>();
        public IAsyncResult BeginWait(AsyncCallback callback, object state)
        {
            if (callback==null)
            {
                throw new ArgumentNullException("callback","callback cannot be null");
            }
            var o=new CallbackObject();
            o.AsyncState = state;
            o.Callback = callback;
            bool execute = false;
           
            if (Interlocked.Decrement(ref this.counter)>=0)
            {
                o.CompletedSynchronously= execute = true;
            }
            else
            {
                queue.Enqueue(o);
            }
            if (execute)
            {
                callback(o);
                o.IsCompleted = true;
            }
            return o;
        }
        public void EndWait(IAsyncResult r)
        {}
        public void Release()
        {
            CallbackObject execute = null;
            
            if (Interlocked.Increment(ref this.counter)<1)
            {
                if (!queue.TryDequeue(out execute))
                {
                    throw new NotImplementedException("ConcurrentQueue.TryDequeue failed");
                }
            }
            else
            {
                if (counter > maxCounter)
                {
                    throw new SemaphoreFullException("Release was called too many times");
                } 
            }
            
            if (execute!=null)
            {
                execute.Callback(execute);
                execute.IsCompleted = true;
            }
        }
    }
