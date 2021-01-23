    public static class ElliotExtensions
    {
        public static Task<T> TaskWithTimeOut<T>(this Task<T> Task, TimeSpan TimeOut)
        {
            TaskCompletionSource<T> _tCS = null;
            System.Threading.Timer _timer = null;
            // create enclosure that captures the Timer and TaskCompletionSource
            TimerCallback _timerCallBack = delegate(Object State) { _tCS.TrySetCanceled(); _timer.Dispose(); };
            //timer will now hold reference to _tCS (and itself) via the delegate. Don't start the timer yet because it is
            //still null.
            _timer = new System.Threading.Timer(_timerCallBack, null, System.Threading.Timeout.InfiniteTimeSpan, System.Threading.Timeout.InfiniteTimeSpan);
            //put the _timer reference into the task's state; now the program holds on to a reference to the Timer and thereby to
            //the TaskCompletionSource
            _tCS = new TaskCompletionSource<T>(_timer); // contains reference to _tCS via enclosure
            _timer.Change(TimeOut, System.Threading.Timeout.InfiniteTimeSpan);
            // a fire-and-forget continuewith races against the timer:
            Task.ContinueWith(
                _task_ => 
                { 
                    if (_task_.IsFaulted) 
                    { 
                        _tCS.TrySetException(_task_.Exception); 
                        (_tCS.Task.AsyncState as System.Threading.Timer).Dispose(); 
                    }
                    if (_task_.IsCanceled) 
                    { 
                        _tCS.TrySetCanceled(); 
                        (_tCS.Task.AsyncState as System.Threading.Timer).Dispose(); 
                    }
                    else 
                    { 
                        _tCS.TrySetResult(_task_.Result); 
                        (_tCS.Task.AsyncState as System.Threading.Timer).Dispose(); 
                    }
                }, TaskContinuationOptions.ExecuteSynchronously);
            return _tCS.Task;
        }
    }
