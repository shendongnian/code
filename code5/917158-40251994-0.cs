        ManualResetEventSlim _mre = new ManualResetEventSlim(false);
        public Task<string> WaitForIdleAndGetErrors()
            {
                return Task.Factory.StartNew(() =>
                {
                    if (!_queue.IsCompleted)
                    {
                        _mre.Wait();
                    }
                    return ErrorsOccurred;
                });
            }
