    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press A for array; L for list. These are run separately to avoid memory management getting in the way of a clean test.");
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.L)
            {
                for (var i = 0; i < 5; i++)
                {
                    Console.WriteLine("List run " + i);
                    TestList();
                    Console.WriteLine();
                }
            }
            else if (key.Key == ConsoleKey.A)
            {
                for (var i = 0; i < 5; i++)
                {
                    Console.WriteLine("Array run " + i);
                    TestArray();
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Done.");
            Console.ReadKey();
        }
        private const int DataSize = 40000000; // The limit of my old laptop :(
        private static int[] GetBaseData()
        {
            return new int[DataSize];
        }
        private static void TestList()
        {
            int[] baseData;
            using (time("creating base data"))
            {
                baseData = GetBaseData();
            }
            List<int> testData;
            using (time("Initialization"))
            {
                testData = new List<int>(DataSize);
            }
            using (time("Populating using FOR (not FOREACH)"))
            {
                var c = baseData.Count();
                for (var i = 0; i < c; i++)
                {
                    testData.Add(baseData[i]);
                }
            }
            using (time("Iterating & retrieving with FOR (not FOREACH)"))
            {
                var c = testData.Count();
                var v = 0;
                var oi = 0;
                for (var i = 0; i < c; i++)
                {
                    oi = testData[i];
                    v += oi;
                }
            }
            using (time("Resizing"))
            {
                testData.Add(1); // Enough to push it over the original limit
            }
        }
        private static void TestArray()
        {
            int[] baseData;
            using (time("creating base data"))
            {
                baseData = GetBaseData();
            }
            int[] o;
            using (time("Initialization"))
            {
                o = new int[DataSize]; // SomeClass[DataSize];
            }
            using (time("Populating with FOR"))
            {
                var c = baseData.Count();
                for (var i = 0; i < c; i++)
                {
                    o[i] = baseData[i];
                }
            }
            using (time("Iterating FOR"))
            {
                var v = 0;
                var c = o.Count();
                var oi = 0;
                for (var i = 0; i < c; i++)
                {
                    oi = o[i];
                    v += oi;
                }
            }
            using (time("Resizing"))
            {
                Array.Resize(ref o, DataSize * 2); // NOTE: this doubles to match List behavior but further efficiencies could be gained with lower values eg. 1.2
            }
        }
        private static TimeAdviser time(string message)
        {
            return new TimeAdviser(DataSize + ": " + message, (x) => Console.WriteLine(x));
        }
        private class TimeAdviser : IDisposable
        {
            public DateTime Start;
            public string Message;
            public Action<string> OnComplete;
            public TimeAdviser(string message, Action<string> onComplete)
            {
                Start = DateTime.Now;
                Message = message;
                OnComplete = onComplete;
            }
            public void Dispose()
            {
                OnComplete(Message + " time taken: " + (DateTime.Now -Start).TotalMilliseconds);
            }
        }
    }
