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
        private Queue<CallbackObject> queue = new Queue<CallbackObject>();
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
            lock (this)
            {
                if (counter>0)
                {
                    o.CompletedSynchronously= execute = true;
                    counter--;
                }
                else
                {
                     queue.Enqueue(o);
                }
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
            lock (this)
            {
                if (!queue.Any())
                {
                    if (++counter > maxCounter)
                    {
                        throw new SemaphoreFullException("Release was called too many times");
                    } 
                }
                else
                {
                    execute = queue.Dequeue();
                }
            }
            if (execute!=null)
            {
                execute.Callback(execute);
                execute.IsCompleted = true;
            }
        }
    }
