    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    
    namespace MyApplication
    {
        public class Debouncer : IDisposable
        {
            TimeSpan _ts;
            Action _action;
            HashSet<ManualResetEvent> _resets = new HashSet<ManualResetEvent>();
            readonly object _mutex = new object();
    
            public Debouncer(TimeSpan timespan, Action action)
            {
                _ts = timespan;
                _action = action;
            }
    
            public void Invoke()
            {
                var thisReset = new ManualResetEvent(false);
    
                lock (_mutex)
                {
                    while (_resets.Count > 0)
                    {
                        var otherReset = _resets.First();
                        _resets.Remove(otherReset);
                        otherReset.Set();
                    }
    
                    _resets.Add(thisReset);
                }
    
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        if (!thisReset.WaitOne(_ts))
                        {
                            _action();
                        }
                    }
                    finally
                    {
                        lock (_mutex)
                        {
                            using (thisReset)
                                _resets.Remove(thisReset);
                        }
                    }
                });
            }
    
            public void Dispose()
            {
                lock (_mutex)
                {
                    while (_resets.Count > 0)
                    {
                        var reset = _resets.First();
                        _resets.Remove(reset);
                        reset.Set();
                    }
                }
            }
        }
    }
