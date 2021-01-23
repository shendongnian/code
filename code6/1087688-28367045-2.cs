    public static class EnumerableExtensions
    {
        public static IEnumerable<Task<TimedResult<T>>> TimedSelect<T>(this IEnumerable<T> source, Func<T, Task<T>> func )
        {
            return source.Select(x =>
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                Task<T> task = func(x);
                Task<TimedResult<T>> timedResultTask = task
                    .ContinueWith(y =>
                    {
                        stopwatch.Stop();
                        return new TimedResult<T>(task, stopwatch.Elapsed);
                    });
                return timedResultTask;
            });
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
