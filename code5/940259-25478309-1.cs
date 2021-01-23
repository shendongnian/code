    static class TaskCompletionSourceExtensions
    {
        /// <summary>
        /// APPROXIMATION of properly associating a CancellationToken with a TCS
        /// so that access to Task.Result following cancellation of the TCS Task 
        /// throws an OperationCanceledException with the proper CancellationToken.
        /// </summary>
        /// <remarks>
        /// If the TCS Task 'RanToCompletion' or Faulted before/despite a 
        /// cancellation request, this may still report TaskStatus.Canceled.
        /// </remarks>
        /// <param name="this">The 'TCS' to 'fix'</param>
        /// <param name="token">The associated CancellationToken</param>
        /// <param name="LazyCancellation">
        /// true to let the 'owner/runner' of the TCS complete the Task
        /// (and stop executing), false to mark the returned Task as Canceled
        /// while that code may still be executing.
        /// </param>
        public static Task<TResult> TaskWithCancellation<TResult>(
            this TaskCompletionSource<TResult> @this,
            CancellationToken token,
            bool lazyCancellation)
        {
            if (lazyCancellation)
            {
                return @this.Task.ContinueWith(
                    (task) => task,
                    token,
                    TaskContinuationOptions.LazyCancellation |
                        TaskContinuationOptions.ExecuteSynchronously,
                    TaskScheduler.Default).Unwrap();
            }
            return @this.Task.ContinueWith((task) => task, token).Unwrap();
            // Yep that was a one liner!
            // However, LazyCancellation (or not) should be explicitly chosen!
        }
        /// <summary>
        /// Attempts to transition the underlying Task into the Canceled state
        /// and set the CancellationToken member of the associated 
        /// OperationCanceledException.
        /// </summary>
        public static bool TrySetCanceled<TResult>(
            this TaskCompletionSource<TResult> @this,
            CancellationToken token)
        {
            return TrySetCanceledCaller<TResult>.MakeCall(@this, token);
        }
        private static class TrySetCanceledCaller<TResult>
        {
            public delegate bool MethodCallerType(TaskCompletionSource<TResult> inst, CancellationToken token);
            
            public static readonly MethodCallerType MakeCall;
            static TrySetCanceledCaller()
            {
                var type = typeof(TaskCompletionSource<TResult>);
                var method = type.GetMethod(
                    "TrySetCanceled",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic,
                    null,
                    new Type[] { typeof(CancellationToken) },
                    null);
                MakeCall = (MethodCallerType)
                    Delegate.CreateDelegate(typeof(MethodCallerType), method);
            }
        }
    }
