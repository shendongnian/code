    class Sync : IDisposable
    {
        private static readonly SemaphoreSlim Semaphore = new SemaphoreSlim(20);
        // -1: semaphore not entered and does not need to be released.
        // 0 : semaphore entered and needs to be released.
        // 1 : semaphore already released.
        private int State = -1;
        private Sync()
        {
        }
        // Renamed to conform to Microsoft's guidelines.
        public static async Task<Sync> AcquireAsync(TimeSpan releaseAfter)
        {
            // State = -1: Disposing sync won't release the semaphore.
            // In case we are unable to enter the semaphore the newly
            // created Sync instance won't call Release unnecessarily
            // when disposed.
            var sync = new Sync();
            await Semaphore.WaitAsync().ConfigureAwait(false);
            try
            {
                // State = 0: from here on sync.Dispose will call
                // Semaphore.Release (until the Sync instance has
                // transisions to State = 1 via ReleaseOnce).
                sync.State = 0; 
                return sync;
            }
            finally
            {
                // Fire-and-forget, not awaited.
                sync.DelayedRelease(releaseAfter);
            }
        }
        private async void DelayedRelease(TimeSpan releaseAfter)
        {
            await Task.Delay(releaseAfter).ConfigureAwait(false);
            this.ReleaseOnce();
        }
        private void ReleaseOnce()
        {
            // Ensure that we call Semaphore.Release() at most
            // once during the lifetime of this instance -
            // either via DelayedRelease, or via Dispose.
            if (Interlocked.Exchange(ref this.State, 1) == 0)
            {
                Semaphore.Release();
            }
        }
        public void Dispose()
        {
            // Uncomment if you want the ability to
            // release the semaphore via Dispose
            // thus bypassing the throttling.
            //this.ReleaseOnce();
        }
    }
