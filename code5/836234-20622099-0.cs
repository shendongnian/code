    class Program
    {
        List<byte[]> myJunkList = new List<byte[]>();
        static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
        }
        public void Run()
        {
            GC.RegisterForFullGCNotification(10, 10);
            var pollingThread = new Thread(() =>
            {
                while (true)
                {
                    var gcStatus = GC.WaitForFullGCApproach(1000);
                    switch (gcStatus)
                    {
                        case GCNotificationStatus.Succeeded:
                            Console.WriteLine("GC has started.");
                            break;
                    }
                    gcStatus = GC.WaitForFullGCComplete(1000);
                    switch (gcStatus)
                    {
                        case GCNotificationStatus.Succeeded:
                            Console.WriteLine("GC has ended.");
                            break;
                    }
                    Thread.Sleep(500);
                }
            });
            pollingThread.Start();
            AllocateMemory();
            GC.CancelFullGCNotification();
        }
        void AllocateMemory()
        {
            var rand = new Random();
            var newCount = 0;
            var oldCount = 0;
            while (true)
            {
                var junk = new byte[1024];
                rand.NextBytes(junk);
                myJunkList.Add(junk);
                newCount = GC.CollectionCount(2);
                if (newCount != oldCount)
                {
                    Console.WriteLine("GC 2 has run {0} times (list now has {1} items).", newCount, myJunkList.Count);
                }
                oldCount = newCount;
            }
        }
