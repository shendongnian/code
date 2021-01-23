        public static Random Randomator { get; set; }
        public const int TimesToRun = 1000000;
        public static Semaphore semaphore;
        public static void ThrowTheDice()
        {
            Randomator = new Random();
            semaphore = new Semaphore(1, 1);
            var resultsParallel = new Dictionary<int, int>
        {
            {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}
        };
            var resultsParallelForEach = new Dictionary<int, int>
        {
            {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}
        };
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.For(0, TimesToRun, ctr =>
            {
                var val = ThrowDice();
                if (!resultsParallel.ContainsKey(val))
                    throw new ArgumentOutOfRangeException();
                semaphore.WaitOne();
                var existing = resultsParallel[val];
                resultsParallel[val] = existing + 1;
                semaphore.Release();
            });
            stopwatch.Stop();
            var parallelTime = stopwatch.Elapsed;
            stopwatch = new Stopwatch();
            stopwatch.Start();
            var numbers = Enumerable.Range(0, TimesToRun);
            Parallel.ForEach(numbers, ctr =>
            {
                var val = ThrowDice();
                if (!resultsParallel.ContainsKey(val))
                    throw new ArgumentOutOfRangeException();
                semaphore.WaitOne();
                var existing = resultsParallelForEach[val];
                resultsParallelForEach[val] = existing + 1;
                semaphore.Release();
            });
            stopwatch.Stop();
            var parallelForEachTime = stopwatch.Elapsed;
            var parallelTotal = resultsParallel.Sum(x => x.Value);
            var parallelForEachTotal = resultsParallelForEach.Sum(x => x.Value);
            Debug.Assert(parallelTotal == TimesToRun);
            Debug.Assert(parallelForEachTotal == TimesToRun);
        }
        public static int ThrowDice()
        {
            return Randomator.Next(1, 7);
        }
    } 
