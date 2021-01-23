    class Program
    {
        static async Task Main(string[] args)
        {
            var cache = new MemoryCache(new MemoryCacheOptions());
            var tasks = new List<Task>();
            var counter = 0;
            for (int i = 0; i < 10; i++)
            {
                var loc = i;
                tasks.Add(Task.Run(() =>
                {
                    var x = GetOrAdd(cache, "test", TimeSpan.FromMinutes(1), () => Interlocked.Increment(ref counter));
                    Console.WriteLine($"Interation {loc} got {x}");
                }));
            }
            await Task.WhenAll(tasks);
            Console.WriteLine("Total value creations: " + counter);
            Console.ReadKey();
        }
        public static T GetOrAdd<T>(IMemoryCache cache, string key, TimeSpan expiration, Func<T> valueFactory)
        {
            return cache.GetOrCreate(key, entry =>
            {
                entry.SetSlidingExpiration(expiration);
                return new Lazy<T>(valueFactory, LazyThreadSafetyMode.ExecutionAndPublication);
            }).Value;
        }
    }
