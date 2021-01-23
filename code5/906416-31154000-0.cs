    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace Quantum
    {
        public delegate void TimerCallback(object state);
    
        public sealed class Timer : IDisposable
        {
            private static Task CompletedTask = Task.FromResult(false);
    
            private TimerCallback Callback;
            private Task Delay;
            private bool Disposed;
            private int Period;
            private object State;
            private CancellationTokenSource TokenSource;
    
            public Timer(TimerCallback callback, object state, int dueTime, int period)
            {
                Callback = callback;
                State = state;
                Period = period;
                Reset(dueTime);
            }
    
            public Timer(TimerCallback callback, object state, TimeSpan dueTime, TimeSpan period)
                : this(callback, state, (int)dueTime.TotalMilliseconds, (int)period.TotalMilliseconds)
            {
            }
    
            ~Timer()
            {
                Dispose(false);
            }
    
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
    
            private void Dispose(bool cleanUpManagedObjects)
            {
                if (cleanUpManagedObjects)
                    Cancel();
                Disposed = true;
            }
    
            public void Change(int dueTime, int period)
            {
                Period = period;
                Reset(dueTime);
            }
    
            public void Change(TimeSpan dueTime, TimeSpan period)
            {
                Change((int)dueTime.TotalMilliseconds, (int)period.TotalMilliseconds);
            }
    
            private void Reset(int due)
            {
                Cancel();
                if (due >= 0)
                {
                    TokenSource = new CancellationTokenSource();
                    Action tick = null;
                    tick = () =>
                    {
                        Task.Run(() => Callback(State));
                        if (!Disposed && Period >= 0)
                        {
                            if (Period > 0)
                                Delay = Task.Delay(Period, TokenSource.Token);
                            else
                                Delay = CompletedTask;
                            Delay.ContinueWith(t => tick(), TokenSource.Token);
                        }
                    };
                    if (due > 0)
                        Delay = Task.Delay(due, TokenSource.Token);
                    else
                        Delay = CompletedTask;
                    Delay.ContinueWith(t => tick(), TokenSource.Token);
                }
            }
    
            private void Cancel()
            {
                if (TokenSource != null)
                {
                    TokenSource.Cancel();
                    TokenSource.Dispose();
                    TokenSource = null;
                }
            }
        }
    }
