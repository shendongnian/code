    class Sync : IDisposable
    {
        private static readonly SemaphoreSlim Semaphore = new SemaphoreSlim(20);
        // 0 : semaphore needs to be released.
        // 1 : semaphore already released.
        private int State = 0;
        private Sync()
        {
        }
        // Renamed to conform to Microsoft's guidelines.
        public static async Task<Sync> AcquireAsync(TimeSpan releaseAfter)
        {
            var sync = new Sync();
            await Semaphore.WaitAsync().ConfigureAwait(false);
            try
            {
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
