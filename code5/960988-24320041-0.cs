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
            public static async Task<Sync> Acquire(TimeSpan releaseAfter)
            {
                // State = -1: Disposing sync won't release the semaphore.
                var sync = new Sync();
                await Semaphore.WaitAsync().ConfigureAwait(false);
                try
                {
                    // State = 0: Call to sync.Dispose() will release the semaphore
                    // unless it has already transisioned to State = 1 via ReleaseOnce by then.
                    sync.State = 0; 
                    return sync;
                }
                finally
                {
                    // Not awaited.
                    sync.DelayedRelease(releaseAfter);
                }
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
            private async void DelayedRelease(TimeSpan releaseAfter)
            {
                await Task.Delay(releaseAfter).ConfigureAwait(false);
                this.ReleaseOnce();
            }
            public void Dispose()
            {
                this.ReleaseOnce();
            }
        }
