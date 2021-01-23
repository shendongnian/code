    // ImposeAsync, TODO: more overrides
    static public Task<TResult> ImposeAsync<TResult>(this Task<TResult> @this)
    {
        return @this.ContinueWith(new Func<Task<TResult>, Task<TResult>>(antecedent =>
        {
            Thread thread = null;
            s_tcsTasks.TryGetValue(antecedent, out thread);
            if (Thread.CurrentThread == thread)
            {
                return antecedent.ContinueWith(t => t, 
                    TaskContinuationOptions.None).Unwrap();
            }
            else
            {
                return antecedent;
            }
        })).Unwrap();
    }
