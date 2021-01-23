    object resourselock = new object();
        public void Test()
        {
            Thread lowestThread = new Thread(new ThreadStart(Low));
            lowestThread.Priority = ThreadPriority.Lowest;
            Thread highestThread = new Thread(new ThreadStart(High));
            highestThread.Priority = ThreadPriority.Highest;
            lowestThread.Start();
            Thread.Sleep(1000);   //makes sure that the lowest priority thread starts first
            highestThread.Start();
        }
        
        public void Low()
        {
            Console.WriteLine("Low priority task executed");
            lock (resourselock)
            {
                Console.WriteLine("Low priority task will never release the lock!");
                while (true) ; //infinite empty statement!
            }
        }
        public void High()
        {
            System.Console.WriteLine("High priority task executed");
            lock (resourselock)
            {
                System.Console.WriteLine("High priority task got the lock!"); //this will never be reached!
            }
        }
