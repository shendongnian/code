        /// <summary>Creates a new Task that mirrors the supplied task but that 
        /// will be canceled after the specified timeout.</summary>
        /// <typeparam name="TResult">Specifies the type of data contained in the 
        /// task.</typeparam>
        /// <param name="task">The task.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns>The new Task that may time out.</returns>
        public static Task<TResult> WithTimeout<TResult>(this Task<TResult> task, 
                                                              TimeSpan timeout)
        {
            var result = new TaskCompletionSource<TResult>(task.AsyncState);
            var timer = new Timer(state => 
                            ((TaskCompletionSource<TResult>)state).TrySetCanceled(),
                            result, timeout, TimeSpan.FromMilliseconds(-1));
            task.ContinueWith(t =>
            {
                timer.Dispose();
                result.TrySetFromTask(t);
            }, TaskContinuationOptions.ExecuteSynchronously);
            return result.Task;
        }
