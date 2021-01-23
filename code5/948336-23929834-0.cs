      public class QueueManager
        {
            public BlockingCollection<Work> blockingCollection = new BlockingCollection<Work>();
            private const int _maxRunningTasks = 3;
    
            static SemaphoreSlim _sem = new SemaphoreSlim(_maxRunningTasks);
    
            public void Queue()
            {
                blockingCollection.Add(new Work());
            }
    
            public void Consume()
            {
                while (true)
                {
                    Work work = blockingCollection.Take();
    
                    _sem.Wait();
    
                    Task t = Task.Factory.StartNew(work.DoWork);
                }
            }
    
            public class Work
            {
                public void DoWork()
                {
                    Thread.Sleep(5000);
                    _sem.Release();
                    Console.WriteLine("Finished work");
                }
            }
        }
