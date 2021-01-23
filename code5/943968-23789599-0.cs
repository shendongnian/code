       var waitHandle = new AutoResetEvent(false);
        Task.Factory.StartNew(() =>
            {
                lock (_padlock)
                {
                   waitHandle.Set();
                    _sharedDictionary = GetSharedDictionary();
                }
            });
       waitHandle.WaitOne();
