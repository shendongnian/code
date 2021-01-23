    class Attempt1
    {
        private static bool shouldThrow = true;
        static void Main(string[] args)
        {
            Generate().RetryWithBackoffStrategy(3, MyRxExtensions.ExponentialBackoff,
                ex =>
                {
                    return ex is NullReferenceException;
                }, Scheduler.TaskPool)
                .Subscribe(
                    OnNext,
                    OnError
                );
            Console.ReadLine();
        }
        private static void OnNext(int val)
        {
            Console.WriteLine("subscriber value is {0} which was seen on threadId:{1}", 
                val, Thread.CurrentThread.ManagedThreadId);
        }
        private static void OnError(Exception ex)
        {
            Console.WriteLine("subscriber bad {0}, which was seen on threadId:{1}", 
                ex.GetType(),
                Thread.CurrentThread.ManagedThreadId);
        }
        static IObservable<int> Generate()
        {
            return Observable.Create<int>(
                o =>
                {
                    Scheduler.TaskPool.Schedule(() =>
                        {
                            if (shouldThrow)
                            {
                                shouldThrow = false;
                                Console.WriteLine("ON ERROR NullReferenceException");
                                o.OnError(new NullReferenceException("Throwing"));
                            }
                            Console.WriteLine("Invoked on threadId:{0}", 
                                Thread.CurrentThread.ManagedThreadId);
                            Console.WriteLine("On nexting 1");
                            o.OnNext(1);
                            Console.WriteLine("On nexting 2");
                            o.OnNext(2);
                            Console.WriteLine("On nexting 3");
                            o.OnNext(3);
                            o.OnCompleted();
                            Console.WriteLine("On complete");
                            Console.WriteLine("Finished on threadId:{0}", 
                                Thread.CurrentThread.ManagedThreadId);
                        });
                    return () => { };
                });
        }
    }
    public static class MyRxExtensions
    {
        /// <summary>
        /// An exponential back off strategy which starts with 1 second and then 4, 9, 16...
        /// </summary>
        public static readonly Func<int, TimeSpan> ExponentialBackoff = n => TimeSpan.FromSeconds(Math.Pow(n, 2));
 
        public static IObservable<T> RetryWithBackoffStrategy<T>(
            this IObservable<T> source,
            int retryCount = 3,
            Func<int, TimeSpan> strategy = null,
            Func<Exception, bool> retryOnError = null,
            IScheduler scheduler = null)
        {
            strategy = strategy ?? MyRxExtensions.ExponentialBackoff;
            int attempt = 0;
            return Observable.Defer(() =>
            {
                return ((++attempt == 1) ? source : source.DelaySubscription(strategy(attempt - 1), scheduler))
                    .Select(item => new Tuple<bool, T, Exception>(true, item, null))
                    .Catch<Tuple<bool, T, Exception>, Exception>(e =>
                        retryOnError(e)
                        ? Observable.Throw<Tuple<bool, T, Exception>>(e)
                        : Observable.Return(new Tuple<bool, T, Exception>(false, default(T), e)));
            })
            .Retry(retryCount)
            .SelectMany(t => t.Item1
                ? Observable.Return(t.Item2)
                : Observable.Throw<T>(t.Item3));
        }
        public static IObservable<T> DelaySubscription<T>(this IObservable<T> source, 
            TimeSpan delay, IScheduler scheduler = null)
        {
            if (scheduler == null)
            {
                return Observable.Timer(delay).SelectMany(_ => source);
            }
            return Observable.Timer(delay, scheduler).SelectMany(_ => source);
        }
    }
