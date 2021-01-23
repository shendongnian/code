    public static class TaskExtensions
    {
        public static Task Delay(this Task task, TimeSpan timeSpan)
        {
            var tcs = new TaskCompletionSource<bool>();
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += (obj, args) =>
            {
                tcs.TrySetResult(true);
            };
            timer.Interval = timeSpan.Milliseconds;
            timer.AutoReset = false;
            timer.Start();
            return tcs.Task;
        } 
    }
