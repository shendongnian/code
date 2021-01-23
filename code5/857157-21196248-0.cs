        private static void Main(string[] args)
        {
            int maxConcurrancy = Environment.ProcessorCount;
            QueuedTaskScheduler qts = new QueuedTaskScheduler(TaskScheduler.Default, maxConcurrancy);
            var highPriortiyScheduler = qts.ActivateNewQueue(0);
            var lowPriorityScheduler = qts.ActivateNewQueue(1);
            
            BlockingCollection<Foo> highPriorityWork = new BlockingCollection<Foo>();
            BlockingCollection<Foo> lowPriorityWork = new BlockingCollection<Foo>();
            Task.Factory.StartNew(() =>
            {
                Parallel.ForEach(highPriorityWork.GetConsumingPartitioner(),  //.GetConsumingPartitioner() is also from ParallelExtensionExtras, it gives better performance than .GetConsumingEnumerable() with Parallel.ForEeach(
                                 new ParallelOptions() { TaskScheduler = highPriortiyScheduler}, 
                                 ProcessWork);
            }, TaskCreationOptions.LongRunning);
            Task.Factory.StartNew(() =>
            {
                Parallel.ForEach(lowPriorityWork.GetConsumingPartitioner(), 
                                 new ParallelOptions() { TaskScheduler = lowPriorityScheduler }, 
                                 ProcessWork);
            }, TaskCreationOptions.LongRunning);
            //Add some work to do here to the highPriorityWork or lowPriorityWork collections
        }
        private static void ProcessWork(Foo work)
        {
            //...
        }
