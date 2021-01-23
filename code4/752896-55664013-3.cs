    public static class TaskConfigurationExtensions
    {
        private static void Empty<T>(T value) { }
        public static async Task ConfigureException(this Task task, bool preserveAggregate)
        {
            if (preserveAggregate)
            {
                await task
                    .ContinueWith(Empty, TaskContinuationOptions.ExecuteSynchronously)
                    .ConfigureAwait(false);
                task.Wait();
                return;
            }
            await task.ConfigureAwait(false);
        }
        public static async Task<T> ConfigureException<T>(this Task<T> task, bool preserveAggregate)
        {
            if (preserveAggregate)
            {
                await task
                    .ContinueWith(Empty, TaskContinuationOptions.ExecuteSynchronously)
                    .ConfigureAwait(false);
                return task.Result;
            }
            return await task.ConfigureAwait(false);
        }
    }
