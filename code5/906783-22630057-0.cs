    static class TaskExtensions
    {
        public static void Forget(this Task task)
        {
        }
    }
    public async Task StartWorkAsync()
    {
        this.WorkAsync().Forget();
    }
