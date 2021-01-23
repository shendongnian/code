    public static class TaskExt
    {
        public static async void Observe<TResult>(Task<TResult> task)
        {
            await task;
        }
    
        public static async Task<TResult> WithObservation(Task<TResult> task)
        {
            try
            {
                return await task;
            }
            catch (Exception ex)
            {
                // Handle ex
                // ...
    
                // Or, observe and re-throw
                task.Observe(); // do this if you want to throw immediately
    
                throw;
            }
        }
    }
