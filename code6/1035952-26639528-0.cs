    class Program
    {
        private static ConcurrentBag<int> _bag;
        public static void Main()
        {
            // Construct and populate the ConcurrentBag
            _bag = new ConcurrentBag<int>();
            var bagPopulateTask = new Task(PopulateBag);
            bagPopulateTask.Start();
            var bagEmptyTask1 = new Task(EmptyBag);
            var bagEmptyTask2 = new Task(EmptyBag);
            var bagEmptyTask3 = new Task(EmptyBag);
            bagEmptyTask1.Start();
            bagEmptyTask2.Start();
            bagEmptyTask3.Start();
            Console.ReadKey();
        }
        private static void EmptyBag()
        {
            int i;
            while (true)
            {
                if (_bag.TryTake(out i))
                {
                    Console.WriteLine("Thread {0} took {1}", Thread.CurrentThread.ManagedThreadId, i);
                }
                else
                {
                    Console.WriteLine("Thread {0} took nothing", Thread.CurrentThread.ManagedThreadId);
                }
                Thread.Sleep(50);
            }
        }
        private static void PopulateBag()
        {
            var i = 0;
            while (i < 1000)
            {
                Console.WriteLine("Thread {0} added {1}", Thread.CurrentThread.ManagedThreadId, i);
                _bag.Add(i);
                i++;
                Thread.Sleep(i);
            }
        }
    }
