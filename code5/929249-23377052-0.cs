    static IEnumerator<Task> GetSequenceOfTasks()
    {
        using (SqlConnection connection = new SqlConnection(base._ConnectionString))
        {
            yield return TestConnectionAsync(connection);
            using (SqlCommand command = new SqlCommand("SomeProcedure", connection))
            {
                yield return ExecuteCommandAsync(command);
            }
        }
    }
    // ...
    // task will complete when ExecuteCommandAsync has completed
    var task = static IEnumerator<Task> GetSequenceOfTasks().RunAsync();
    // ...
    // execute a sequence of tasks, propagate exceptions and cancellation (if any)
    public static class TaskExt
    {
        public static Task<object> RunAsync(this IEnumerator<Task> @this)
        {
            if (@this == null)
                throw new ArgumentNullException();
            var tcs = new TaskCompletionSource<object>();
            Action<Task> nextStep = null;
            nextStep = (previousTask) =>
            {
                try
                {
                    if (previousTask.IsCanceled)
                        tcs.SetCanceled();
                    else if (previousTask.IsFaulted)
                        tcs.SetException(previousTask.Exception);
                    else
                    {
                        // move to the next task
                        if (@this.MoveNext())
                        {
                            @this.Current.ContinueWith(nextStep,
                                TaskContinuationOptions.ExecuteSynchronously);
                        }
                        else
                            tcs.SetResult(previousTask);
                    }
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            };
            nextStep(Task.FromResult(Type.Missing));
            return tcs.Task.ContinueWith(
                completedTask => { @this.Dispose(); return completedTask; },
                TaskContinuationOptions.ExecuteSynchronously).Unwrap();
        }
    }
