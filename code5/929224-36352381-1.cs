    public static class TaskExtension
    {
        public static async Task WhenAll(this List<Func<Task>> actions, int threadCount)
        {
            var _countdownEvent = new CountdownEvent(actions.Count);
            var _throttler = new SemaphoreSlim(threadCount);
            
            foreach (Func<Task> action in actions)
            {
                await _throttler.WaitAsync();
                
                Task.Run(async () =>
                {
                    try
                    {
                        await action();
                    }
                    finally
                    {
                        _throttler.Release();
                        _countdownEvent.Signal();
                    }
                });
            }
            
            _countdownEvent.Wait();
        }
    }
