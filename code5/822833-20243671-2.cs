      public static class ElliotExtensions
        {
            public static Task<T> TaskWithTimeOut<T>(this Task<T> Task, TimeSpan TimeOut)
            {
                TaskCompletionSource<T> _tCS = null;
    
                // create enclosure to capture _tCS
                TimerCallback _timerCallBack = delegate(Object State) { _tCS.TrySetCanceled(); };
    
                //timer will hold reference to _tCS via the delegate. Don't start the timer
                // yet since _tCS is still null.
                System.Threading.Timer _timer = new System.Threading.Timer(_timerCallBack, null, System.Threading.Timeout.InfiniteTimeSpan, System.Threading.Timeout.InfiniteTimeSpan);
    
                //put the _timer reference into the task's state; now the program holds on to a reference to the Timer and thereby to
                //the TaskCompletionState
                _tCS = new TaskCompletionSource<T>(_timer); // contains reference to _tCS via enclosure
    
                _timer.Change(TimeOut, System.Threading.Timeout.InfiniteTimeSpan);
    
                // a fire-and-forget continuewith
                Task.ContinueWith(_task_ => { if (_task_.IsFaulted) { _tCS.TrySetException(_task_.Exception); } else if (_task_.IsCanceled) { _tCS.TrySetCanceled(); } else { _tCS.TrySetResult(_task_.Result); } }, TaskContinuationOptions.ExecuteSynchronously);
    
                return _tCS.Task;
            }
        }
