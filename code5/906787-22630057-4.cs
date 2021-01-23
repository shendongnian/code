    static class TaskExtensions
    {
        public static void Forget(this Task task)
        {
            task.ContinueWith(
                t => { WriteLog(t.Exception); },
                TaskContinuationOptions.OnlyOnFaulted);
        }
    }
    public async Task StartWorkAsync()
    {
        this.WorkAsync().Forget();
    }
