    class Program
    {
        static List<int> list = new List<int>();
        static ConcurrentBag<int> bag = new ConcurrentBag<int>();
        static ConcurrentStack<int> stack = new ConcurrentStack<int>();
        static ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
        static void Main(string[] args)
        {
            list = new List<int>();
            run(addList);
            run(takeList);
            list = null;
            GC.Collect();
            bag = new ConcurrentBag<int>();
            run(addBag);
            run(takeBag);
            bag = null;
            GC.Collect();
            stack = new ConcurrentStack<int>();
            run(addStack);
            run(takeStack);
            stack = null;
            GC.Collect();
            queue = new ConcurrentQueue<int>();
            run(addQueue);
            run(takeQueue);
            queue = null;
            GC.Collect();
            Console.ReadLine();
        }
        private static void takeList(int obj)
        {
            lock (list)
            {
                if (list.Count == 0)
                    return;
                int output = list[obj];
            }
        }
        private static void takeStack(int obj)
        {
            stack.TryPop(out int output);
        }
        private static void takeQueue(int obj)
        {
            queue.TryDequeue(out int output);
        }
        private static void takeBag(int obj)
        {
            bag.TryTake(out int output);
        }
        private static void addList(int obj) { lock (list) { list.Add(obj); } }
        private static void addStack(int obj) { stack.Push(obj); }
        private static void addQueue(int obj) { queue.Enqueue(obj); }
        private static void addBag(int obj) { bag.Add(obj); }
        private static void run(Action<int> action)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Parallel.For(0, 10000000, new ParallelOptions()
            {
                MaxDegreeOfParallelism = 8
            }, action);
            stopwatch.Stop();
            Console.WriteLine(action.Method.Name + " takes " + stopwatch.Elapsed);
        }
    }
