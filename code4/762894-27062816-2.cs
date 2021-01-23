    public class OperationWithTimeout
    {
        public Task<object> Execute(Func<CancellationToken, object> operation, TimeSpan timeout)
        {
            var cancellationToken = new CancellationTokenSource();
            // Two tasks are created. 
            // One which starts the requested operation and second which starts Timer. 
            // Timer is set to AutoReset = false so it runs only once after given 'delayTime'. 
            // When this 'delayTime' has elapsed then TaskCompletionSource.TrySetResult() method is executed. 
            // This method attempts to transition the 'delayTask' into the RanToCompletion state.
            Task<object> operationTask = Task<object>.Factory.StartNew(() => operation(cancellationToken.Token), cancellationToken.Token);
            Task delayTask = Delay(timeout.TotalMilliseconds);
            // Then WaitAny() waits for any of the provided task objects to complete execution.
            Task[] tasks = new Task[]{operationTask, delayTask};
            Task.WaitAny(tasks);
            try
            {
                if (!operationTask.IsCompleted)
                {
                    // If operation task didn't finish within given timeout call Cancel() on token and throw 'TimeoutException' exception.
                    // If Cancel() was called then in the operation itself the property 'IsCancellationRequested' will be equal to 'true'.
                    cancellationToken.Cancel();
                    throw new TimeoutException("Timeout waiting for method after " + timeout + ". Method was to slow :-)");
                }
            }
            finally
            {
                cancellationToken.Dispose();
            }
            return operationTask;
        }
        public static Task Delay(double delayTime)
        {
            var completionSource = new TaskCompletionSource<bool>();
            Timer timer = new Timer();
            timer.Elapsed += (obj, args) => completionSource.TrySetResult(true);
            timer.Interval = delayTime;
            timer.AutoReset = false;
            timer.Start();
            return completionSource.Task;
        }
    }
