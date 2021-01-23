       public async Task Poll(Func<bool> condition, TimeSpan timeout, string message = null)
        {
            // https://github.com/dotnet/corefx/blob/3b24c535852d19274362ad3dbc75e932b7d41766/src/Common/src/CoreLib/System/Threading/ReaderWriterLockSlim.cs#L233 
            var timeoutTracker = new TimeoutTracker(timeout);
            while (!condition())
            {
                await Task.Yield();
                if (timeoutTracker.IsExpired)
                {
                    if (message != null) throw new TimeoutException(message);
                    else throw new TimeoutException();
                }
            }
        }
