    /// <summary>
    /// AsyncOperation
    /// By Noseratio - http://stackoverflow.com/a/21427264
    /// </summary>
    /// <typeparam name="T">Task result type</typeparam>
    class AsyncOperation<T>
    {
        readonly object _lock = new Object();
        Task<T> _currentTask = null;
        CancellationTokenSource _currentCts = null;
        // a client of this class (e.g. a ViewModel) has an option 
        // to handle TaskSucceeded or TaskFailed, if needed
        public EventHandler<TaskEventArgs> TaskSucceeded = null;
        public EventHandler<TaskEventArgs> TaskFailing = null;
        public Task<T> CurrentTask
        {
            get
            {
                lock (_lock)
                    return _currentTask;
            }
        }
        public bool IsCurrent(Task task)
        {
            lock (_lock)
                return task == _currentTask;
        }
        public bool IsPending
        {
            get
            {
                lock (_lock)
                    return _currentTask != null && !_currentTask.IsCompleted;
            }
        }
        public bool IsCancellationRequested
        {
            get
            {
                lock (_lock)
                    return _currentCts != null && _currentCts.IsCancellationRequested;
            }
        }
        public void Cancel()
        {
            lock (_lock)
            {
                if (_currentTask != null && !_currentTask.IsCompleted)
                    _currentCts.Cancel();
            }
        }
        /// <summary>
        /// Start the task routine and observe the result of the previous task routine
        /// </summary>
        /// <param name="routine"></param>
        /// <param name="token"></param>
        /// <param name="cancelPrevious"></param>
        /// <param name="throwImmediately"></param>
        public Task<T> StartAsync(
            Func<CancellationToken, Task<T>> routine,
            CancellationToken token,
            bool cancelPrevious = true,
            bool throwImmediately = true)
        {
            Task<T> previousTask = null; // pending instance
            CancellationTokenSource previousCts = null; // pending instance CTS
            CancellationTokenSource thisCts = CancellationTokenSource.CreateLinkedTokenSource(token);
            TaskCompletionSource<T> thisTcs = new TaskCompletionSource<T>(); // this task
            CancellationToken thisToken; // this task's cancellation Token
            Task<T> routineTask = null; // as returned by routine
            lock (_lock)
            {
                // remember the _currentTask as previousTask
                previousTask = _currentTask;
                previousCts = _currentCts;
                thisToken = thisCts.Token;
                // set the new _currentTask 
                _currentTask = thisTcs.Task;
                _currentCts = thisCts;
            }
            Action startAsync = async () =>
            {
                // because startAsync is "async void" method, 
                // any exception not handled inside it
                // will be immediately thrown on the current synchronization context,
                // more details: http://stackoverflow.com/a/22395161/1768303
                // run and await this task
                try
                {
                    // await the previous task instance
                    if (previousTask != null)
                    {
                        if (cancelPrevious)
                            previousCts.Cancel();
                        try
                        {
                            await previousTask;
                        }
                        catch (OperationCanceledException)
                        {
                            // ignore previous cancellations
                        }
                    }
                    thisToken.ThrowIfCancellationRequested();
 
                    routineTask = routine(thisToken);
                    await routineTask;
                }
                catch (Exception ex)
                {
                    // ignore cancellation
                    if (ex is OperationCanceledException)
                    {
                        System.Diagnostics.Debug.Print("Task cancelled, id={0}", thisTcs.Task.Id);
                        thisTcs.SetCanceled();
                        return;
                    }
                    // fire TaskFailing
                    System.Diagnostics.Debug.Print("Task failing, id={0}", thisTcs.Task.Id);
                    if (this.TaskFailing != null)
                    {
                        var args = new TaskEventArgs(thisTcs.Task, ex);
                        this.TaskFailing(this, args);
                        if (args.Handled)
                        {
                            // exception handled
                            // make thisTcs cancelled rather than faulted 
                            thisTcs.SetCanceled();
                            return;
                        }
                    }
                    // exception unhandled
                    thisTcs.SetException(ex);
                    if (throwImmediately)
                        throw; // rethrow on the current synchronization context
                    // exception should be observed via CurrentTask.Exception
                    return;
                }
                // success, fire TaskSucceeded
                System.Diagnostics.Debug.Print("Task succeded, id={0}", thisTcs.Task.Id);
                thisTcs.SetResult(routineTask.Result);
                if (this.TaskSucceeded != null)
                    this.TaskSucceeded(this, new TaskEventArgs(thisTcs.Task));
            };
            startAsync();
            return thisTcs.Task;
        }
        // StartAsync with CancellationToken.None
        public Task<T> StartAsync(
            Func<CancellationToken, Task<T>> routine,
            bool cancelPrevious = true,
            bool throwImmediately = true)
        {
            return StartAsync(routine, CancellationToken.None, cancelPrevious: true, throwImmediately: true);
        }
        /// <summary>
        /// TaskEventArgs
        /// </summary>
        public class TaskEventArgs : EventArgs
        {
            public Task<T> Task { get; private set; }
            public Exception Exception { get; private set; }
            public bool Handled { get; set; }
            public TaskEventArgs(Task<T> task, Exception exception = null)
            {
                this.Task = task;
                this.Exception = exception;
            }
        }
    }
