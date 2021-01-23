    public static class TaskExtensions
    {
        public static Task<TimedResult<T>> Timed<T>(this Task<T> task)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var timedResultTask = task
                .ContinueWith(y =>
                {
                    stopwatch.Stop();
                    return new TimedResult<T>(task, stopwatch.Elapsed);
                });
            return timedResultTask;
        }
    }
    public class TimedResult<T>
    {
        internal TimedResult(Task<T> task, TimeSpan duration)
        {
            Task = task;
            Duration = duration;
        }
        public readonly Task<T> Task;
        public readonly TimeSpan Duration;
    }
