    public static class ElliotExtensions
    {
        public static Task<T> TaskWithTimeOut<T>(this Task<T> Task, TimeSpan TimeOut)
        {
            TaskCompletionSource<T> _tCS = null;
            System.Threading.Timer _timer = null;
            // create enclosure that captures the Timer and TaskCompletionSource
            TimerCallback _timerCallBack = delegate(Object State) { _tCS.TrySetCanceled(); _timer.Dispose(); };
            //timer now holds reference to _tCS (and itself) via the delegate. Don't start the timer yet because it is
            //still null.
            _timer = new System.Threading.Timer(_timerCallBack, null, System.Threading.Timeout.InfiniteTimeSpan, System.Threading.Timeout.InfiniteTimeSpan);
            //put the _timer reference into the task's state; now the program holds on to a reference to the Timer and thereby to
            //the TaskCompletionState
            _tCS = new TaskCompletionSource<T>(_timer); // contains reference to _tCS via enclosure
            _timer.Change(TimeOut, System.Threading.Timeout.InfiniteTimeSpan);
            // a fire-and-forget continuewith
            Task.ContinueWith(
                _task_ =>
                {
                    TaskStatus _status = _task_.Status;
                    switch (_status)
                    {
                        case TaskStatus.RanToCompletion:
                            _tCS.TrySetResult(_task_.Result);
                            break;
                        case TaskStatus.Canceled:
                            _tCS.TrySetCanceled();
                            break;
                        case TaskStatus.Faulted:
                            _tCS.TrySetException(_task_.Exception);
                            break;
                    }
                    (_task_.AsyncState as System.Threading.Timer).Dispose();
                }, TaskContinuationOptions.ExecuteSynchronously);
            return _tCS.Task;
        }
    }
