        private static readonly Object obj = new Object();
        static List<string> list1 = new List<string> { "1", "2", "3", "4" };
        static List<string> list2 = new List<string> { "a", "b", "c", "d", "e" };
        static List<string> list3 = new List<string> { "*", "+", "-", "?" };
        static int i = 0;
        //thread synchronization data
        const int numThreads = 3;
        static int workingCount = 0;
        static int lastItem = 0;
        static object locker = new object();
        static void Main(string[] args)
        {
            Thread t1 = new Thread(PrintItem);
            t1.Name = "Print1";
            Thread t2 = new Thread(PrintItem);
            t2.Name = "Print2";
            Thread t3 = new Thread(PrintItem);
            t3.Name = "Print3";
            t1.Start(0);
            t2.Start(1);
            t3.Start(2);
            t1.Join();
            t2.Join();
            t3.Join();
            Console.ReadLine();
        }
        private static void PrintItem(object state)
        {
            Interlocked.Increment(ref workingCount);
            int workingList = (int)state;
            int idx = 0;
            List<string> list = null;
            switch (workingList)
            {
                case 0:
                    list = list1;
                    break;
                case 1:
                    list = list2;
                    break;
                case 2:
                    list = list3;
                    break;
            }
            lock (locker)
                do
                {
                    while ((lastItem % numThreads) != workingList)
                    {
                        Monitor.Wait(locker);
                    }
                    Console.WriteLine("Thread: {0}\tValue: {1}", Thread.CurrentThread.Name, list[idx]);
                    lastItem++;
                    Monitor.PulseAll(locker);
                } while (++idx < list.Count);
            //Handle continuing to pulse until all lists are done.
            Interlocked.Decrement(ref workingCount);
            lock (locker)
                while (workingCount != 0)
                {
                    while ((lastItem % numThreads) != workingList)
                        Monitor.Wait(locker);
                    lastItem++;
                    Monitor.PulseAll(locker);
                }
        }
    }
