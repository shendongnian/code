    public static class TaskConfigurationExtensions
    {
        public static async Task ConfigureException(this Task task, bool preserveAggregate)
        {
            try
            {
                await task.ConfigureAwait(false); // Because the context doesn't have to be resumed on to throw.
            }
            catch
            {
                if (preserveAggregate) throw task.Exception;
                throw;
            }
        }
        public static async Task<T> ConfigureException<T>(this Task<T> task, bool preserveAggregate)
        {
            try
            {
                return await task.ConfigureAwait(false);
            }
            catch
            {
                if (preserveAggregate) throw task.Exception;
                throw;
            }
        }
    }
