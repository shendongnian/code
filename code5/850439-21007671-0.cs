    public override void Post(SendOrPostCallback d, object state)
        {
            _queue.Enqueue(new CallbackInfo(d, state));
            bool lockTaken = false;
            try
            {
                Monitor.TryEnter(_lock, ref lockTaken);
                if (lockTaken)
                {
                    ProcessQueue();
                }
                else
                {
                    Task.Run((Action)ProcessQueue);
                }
            }
            finally
            {
                if (lockTaken)
                {
                    Monitor.Exit(_lock);
                }
            }
        }
        // ...
        private void ProcessQueue()
        {
            if (!_queue.IsEmpty)
            {
                lock (_lock)
                {
                    var outer = SynchronizationContext.Current;
                    try
                    {
                        SynchronizationContext.SetSynchronizationContext(this);
                        CallbackInfo callback;
                        while (_queue.TryDequeue(out callback))
                        {
                            try
                            {
                                callback.D(callback.State);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Exception in posted callback on {0}: {1}", 
                                    GetType().FullName, e);                 
                            }
                        }
                    }
                    finally
                    {
                        SynchronizationContext.SetSynchronizationContext(outer);
                    }
                }
            }
        }
