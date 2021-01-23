        public static Task<TResult> Catch<TResult>(this Task<TResult> self, Action<Exception> exceptionHandlerTask)
        {
            return self.ContinueWith(s =>
            {
                if (!s.IsFaulted)
                {
                    return s.Result;
                }
                exceptionHandlerTask(s.Exception);
                return default(TResult);
            },
            CancellationToken.None,
            TaskContinuationOptions.ExecuteSynchronously |
            TaskContinuationOptions.DenyChildAttach,
            TaskScheduler.Default);
        }
