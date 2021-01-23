        public static Task Delay(int milliseconds, CancellationToken token)
        {
            var tcs = new TaskCompletionSource<object>();
            var timer = new OneShotTimer((t) => {
                using ((OneShotTimer)t)
                    tcs.SetResult(null);
            });
            token.Register(() => {
                if (timer.TryCancel())
                {
                    using (timer)
                        tcs.SetCanceled();
                }
            });
            timer.Start(milliseconds);
            return tcs.Task;
        }
        public class OneShotTimer : IDisposable
        {
            private readonly object sync = new object();
            private readonly TimerCallback oneShotCallback;
            private readonly Timer timer;
            private bool isActive;
            public OneShotTimer(TimerCallback oneShotCallback, int dueTime = Timeout.Infinite)
            {
                this.oneShotCallback = oneShotCallback;
                this.isActive = dueTime != Timeout.Infinite;
                this.timer = new Timer(callback, this, dueTime, Timeout.Infinite);
            }
        
            public void Dispose()
            {
                timer.Dispose();
            }
            public void Start(int dueTime)
            {
                if (!tryChange(true, dueTime))
                    throw new InvalidOperationException("The timer has already been started");
            }
            public bool TryCancel()
            {
                return tryChange(false, Timeout.Infinite);
            }
            public bool tryChange(bool targetIsActive, int dueTime)
            {
                bool result = false;
                lock (sync)
                {
                    if (isActive != targetIsActive)
                    {
                        result = true;
                        isActive = targetIsActive;
                        timer.Change(dueTime, Timeout.Infinite);
                    }
                }
                return result;
            }
            private static void callback(object state)
            {
                var oneShotTimer = (OneShotTimer)state;
                if (oneShotTimer.TryCancel())
                    oneShotTimer.oneShotCallback(oneShotTimer);
            }
        }
