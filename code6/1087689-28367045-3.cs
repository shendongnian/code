    public static class EnumerableExtensions
    {
        public static IEnumerable<Task<TimedResult<TReturn>>> TimedSelect<TSource, TReturn>(
            this IEnumerable<TSource> source,
            Func<TSource, Task<TReturn>> func )
        {
            if (source == null) throw new ArgumentNullException("source");
            if (func == null) throw new ArgumentNullException("func");
            return source.Select(x =>
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                Task<TReturn> task = func(x);
                Task<TimedResult<TReturn>> timedResultTask = task
                    .ContinueWith(y =>
                    {
                        stopwatch.Stop();
                        return new TimedResult<TReturn>(task, stopwatch.Elapsed);
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
